/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *******************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.ADM;

namespace AgGateway.ADAPT.PluginManager
{
   public interface IPluginFactory
   {
      List<string> AvailablePlugins { get; }
   }

   public class PluginFactory : IPluginFactory
   {
      private readonly IFileSystem _fileSystem;
      private readonly string _pluginDirectory;
      private readonly IPluginLoader _pluginLoader;
      private readonly List<PluginMetadata> _availablePlugins;

      public PluginFactory(string pluginDirectory)
         : this(new FileSystem(), pluginDirectory, new PluginLoader())
      {

      }

      public PluginFactory(IFileSystem fileSystem, string pluginDirectory, IPluginLoader pluginLoader)
      {
         _fileSystem = fileSystem;
         _pluginLoader = pluginLoader;
         _pluginDirectory = string.IsNullOrWhiteSpace(pluginDirectory) ? Directory.GetCurrentDirectory() : pluginDirectory;
         _pluginLoader.SetupDependencyResolver(_pluginDirectory);
         _availablePlugins = new List<PluginMetadata>();
      }

      public IPlugin GetPlugin(string name)
      {
         EnsurePluginsAreLoaded();
         var metaData = GetMetadata(name);
         return metaData.AssemblyInstance ?? (metaData.AssemblyInstance = _pluginLoader.CreateInstance(metaData));
      }

      private PluginMetadata GetMetadata(string pluginName)
      {
         var metaData = _availablePlugins.FirstOrDefault(x => x.Name == pluginName);
         if (metaData == null)
         {
            throw new NotSupportedException("Plugin Not Found!");
         }
         return metaData;
      }

      public List<string> AvailablePlugins
      {
         get
         {
            EnsurePluginsAreLoaded();
            return _availablePlugins.Select(x => x.Name).ToList();
         }
      }

      private void EnsurePluginsAreLoaded()
      {
         if (_availablePlugins.Any())
            return;

         LoadPlugins();
      }

      private void LoadPlugins()
      {
         LoadPlugins(_pluginDirectory);
         foreach (var subDirectory in _fileSystem.GetSubDirectories(_pluginDirectory))
            LoadPlugins(subDirectory);
      }

      private void LoadPlugins(string directory)
      {
         var pluginDlls = _fileSystem.GetFiles(directory, "*.dll");
         foreach (var pluginDll in pluginDlls)
            LoadPlugin(pluginDll);
      }

      private void LoadPlugin(string assemblyLocation)
      {
         var pluginInfo = _pluginLoader.InspectAssembly(assemblyLocation);
         if (pluginInfo != null)
         {
            PopulateMetadata(pluginInfo);
         }
      }

      private void PopulateMetadata(PluginMetadata pluginInfo)
      {
         var existingPlugin = _availablePlugins
             .FirstOrDefault(p => p.Name == pluginInfo.Name);

         if (existingPlugin != null)
         {
            _availablePlugins.Remove(existingPlugin);
         }

         _availablePlugins.Add(pluginInfo);
      }
   }
}
