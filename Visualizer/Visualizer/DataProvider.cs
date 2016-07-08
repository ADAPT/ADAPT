/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
 * Copyright (C) 2015-16 Deere and Company
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors:
 *    Tarak Reddy - initial implementation
 *******************************************************************************/

using System.Collections.Generic;
using System.Collections.ObjectModel;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.PluginManager;

namespace AgGateway.ADAPT.Visualizer
{
    public class DataProvider
    {
        private PluginFactory _pluginFactory;

        public void Initialize(string pluginsPath)
        {
            _pluginFactory = new PluginFactory(pluginsPath);
        }

        public ObservableCollection<string> AvailablePlugins
        {
            get
            {
                if(_pluginFactory == null)
                    return new ObservableCollection<string>();

                return new ObservableCollection<string>(PluginFactory.AvailablePlugins);
            }
        }

        public PluginFactory PluginFactory
        {
            get { return _pluginFactory; }
        }

        public IList<ApplicationDataModel.ADM.ApplicationDataModel> Import(string datacardPath, string initializeString)
        {
            foreach (var availablePlugin in AvailablePlugins)
            {
                var plugin = GetPlugin(availablePlugin);
                InitializePlugin(plugin, initializeString);

                if (plugin.IsDataCardSupported(datacardPath))
                {
                    return plugin.Import(datacardPath);
                }
            }

            return null;
        }

        public IPlugin GetPlugin(string pluginName)
        {
            return _pluginFactory.GetPlugin(pluginName);
        }

        public static void Export(IPlugin plugin, ApplicationDataModel.ADM.ApplicationDataModel applicationDataModel, string initializeString, string exportPath)
        {
            InitializePlugin(plugin, initializeString);

            plugin.Export(applicationDataModel, exportPath);
        }

        private static void InitializePlugin(IPlugin plugin, string initializeString)
        {
            if (!string.IsNullOrEmpty(initializeString))
            {
                plugin.Initialize(initializeString);
            }
        }
    }
}