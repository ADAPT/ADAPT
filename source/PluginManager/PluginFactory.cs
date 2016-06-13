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
      /// <summary>
      /// Returns a list of all available plugin names. 
      /// </summary>
      List<string> AvailablePlugins { get; }

      /// <summary>
      /// Given a plugin name, load and return an actual instance of that plugin. 
      /// </summary>
      /// <param name="pluginName">Name of the plugin to load. The plugin name should be
      /// contained in the AvailablePlugins list.</param>
      /// <returns>An instance of the given plugin's implementation of the IPlugin interface</returns>
      IPlugin GetPlugin(string pluginName);

      /// <summary>
      /// Find all plugins which are able to read a given data set. Relies on the IPlugin.IsDatacardSupported method.
      /// </summary>
      /// <param name="dataPath">The filesystem location of the data you would like to import.</param>
      /// <param name="properties">Optional key/value pair configuration object.</param>
      /// <returns>List of IPlugin implementations which are able to import the given data. 
      /// May return an empty list if no plugins are loaded, or if no plugin can read the given data location.</returns>
      List<IPlugin> GetSupportedPlugins(string dataPath, Properties properties = null);
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
           _pluginDirectory = string.IsNullOrWhiteSpace(pluginDirectory)
               ? Directory.GetCurrentDirectory()
               : pluginDirectory;
           _pluginLoader.SetupDependencyResolver(_pluginDirectory);
           _availablePlugins = new List<PluginMetadata>();
       }

       public IPlugin GetPlugin(string name)
       {
           EnsurePluginsAreLoaded();
           var metaData = GetMetadata(name);
           return metaData.AssemblyInstance ?? (metaData.AssemblyInstance = _pluginLoader.CreateInstance(metaData));
       }

       public List<string> AvailablePlugins
       {
           get
           {
               EnsurePluginsAreLoaded();
               return _availablePlugins.Select(x => x.Name).ToList();
           }
       }

       public List<IPlugin> GetSupportedPlugins(string dataPath, Properties properties = null)
       {
           return AvailablePlugins.Select(GetPlugin)
               .Where(plugin => plugin.IsDataCardSupported(dataPath, properties)).ToList();
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
