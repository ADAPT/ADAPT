using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AgGateway.ADAPT.ApplicationDataModel.PluginProperties
{
    /*
     * Known properties (KeyName, Type):
     * 
     * "LatencySettings", LatencySettings
     * "DesiredUnitSystem", UnitOfMeasureSystem
     */
    public class Properties
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        public void SetProperty(string key, object value)
        {
            if (_properties.ContainsKey(key))
            {
                _properties[key] = value;
            }
            else
            {
                _properties.Add(key, value);
            }
        }

        public object GetProperty(string key)
        {
            if (!_properties.ContainsKey(key))
                return null;
            return _properties[key];
        }

        public ReadOnlyDictionary<string, object> GetAllProperties()
        {
            return new ReadOnlyDictionary<string, object>(_properties);
        }
    }
}