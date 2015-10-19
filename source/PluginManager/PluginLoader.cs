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
using System.Linq;
using System.Reflection;
using AgGateway.ADAPT.ApplicationDataModel;

namespace Adapt.PluginManager
{
    public interface IPluginLoader
    {
        PluginMetadata InspectAssembly(string assemblyLocation);
        IPlugin CreateInstance(PluginMetadata pluginMetadata);
        void SetupDependencyResolver(string pluginDirectory);
    }

    public class PluginLoader : IPluginLoader
    {
        private readonly IAssemblyResolver _assemblyResolver;
        private readonly string _pluginInterfaceName;
        private Boolean _isAssemblyResolverRegistered;

        public PluginLoader() : this(new AssemblyResolver(), typeof (IPlugin).FullName)
        {
        }

        public PluginLoader(IAssemblyResolver assemblyResolver, string pluginInterfaceName)
        {
            _assemblyResolver = assemblyResolver;
            _pluginInterfaceName = pluginInterfaceName;
        }

        public PluginMetadata InspectAssembly(string assemblyLocation)
        {
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFile(assemblyLocation);
            }
            catch (BadImageFormatException)
            {
                return null;
            }

            var pluginType = GetPluginType(assembly);
            var productAttribute = (AssemblyProductAttribute) assembly.GetCustomAttribute(typeof (AssemblyProductAttribute));

            if (pluginType == null
                || productAttribute == null)
            {
                return null;
            }

            var version = pluginType.Assembly.GetName().Version;
            var className = pluginType.FullName;
            var pluginName = productAttribute.Product;

            return PopulateMetadata(pluginName, version, className, assemblyLocation);
        }

        private Type GetPluginType(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes().FirstOrDefault(x => x.GetInterface(_pluginInterfaceName, true) != null);
            }
            catch (ReflectionTypeLoadException)
            {
                return null;
            }
        }

        private PluginMetadata PopulateMetadata(string name, Version version, string className, string assemblyLocation)
        {
            var plugin = new PluginMetadata
            {
                Name = name,
                ModelVersion = version,
                EntryClass = className,
                AssemblyLocation = assemblyLocation
            };
            return plugin;
        }

        public IPlugin CreateInstance(PluginMetadata pluginMetadata)
        {
            var assembly = Assembly.LoadFile(pluginMetadata.AssemblyLocation);
            var pluginEntryClass = assembly.GetType(pluginMetadata.EntryClass);

            pluginMetadata.AssemblyInstance = (IPlugin) Activator.CreateInstance(pluginEntryClass, null);
            return pluginMetadata.AssemblyInstance;
        }

        public void SetupDependencyResolver(string pluginDirectory)
        {
            if (_isAssemblyResolverRegistered)
            {
                return;
            }

            _assemblyResolver.PluginDirectory = pluginDirectory;
            AppDomain.CurrentDomain.AssemblyResolve += _assemblyResolver.LoadFromPluginDirectory;
            _isAssemblyResolverRegistered = true;
        }
    }
}
