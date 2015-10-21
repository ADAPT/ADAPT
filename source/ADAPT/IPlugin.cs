using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public interface IPlugin
    {
        string Name { get; }
        string Version { get; }
        string Owner { get; }
        void Initialize(string args = null);
        bool IsDataCardSupported(string dataPath, Properties properties = null);
        List<IError> ValidateDataOnCard(string dataPath, Properties properties = null);
        ApplicationDataModel Import(string dataPath, Properties properties = null);
        void Export(ApplicationDataModel dataModel, string exportPath, Properties properties = null);
        Properties GetProperties(string dataPath);
    }

    public interface IError
    {
        string Id { get; }
        string Source { get; }
        string Description { get; }
        string StackTrace { get; }
    }

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
