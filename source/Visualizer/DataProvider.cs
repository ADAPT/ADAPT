using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel;
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

        public List<string> AvailablePlugins
        {
            get { return PluginFactory.AvailablePlugins; }
        }

        public PluginFactory PluginFactory
        {
            get { return _pluginFactory; }
        }



        public ApplicationDataModel.ApplicationDataModel Import(string datacardPath, string initializeString)
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

        public static void Export(IPlugin plugin, ApplicationDataModel.ApplicationDataModel applicationDataModel, string initializeString, string exportPath)
        {
            InitializePlugin(plugin, initializeString);

            plugin.Export(applicationDataModel, exportPath);
        }

        private static void InitializePlugin(IPlugin plugin, string initializeString)
        {
            if (string.IsNullOrEmpty(initializeString))
            {
                plugin.Initialize(initializeString);
            }
        }
    }
}