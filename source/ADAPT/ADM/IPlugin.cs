using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel.ADM
{
    public interface IPlugin
    {
        string Name { get; }
        string Version { get; }
        string Owner { get; }
        void Initialize(string args = null);
        bool IsDataCardSupported(string dataPath, Properties properties = null);
        IList<IError> ValidateDataOnCard(string dataPath, Properties properties = null);
        IList<ApplicationDataModel> Import(string dataPath, Properties properties = null);
        void Export(ApplicationDataModel dataModel, string exportPath, Properties properties = null);
        Properties GetProperties(string dataPath);
        IList<IError> Errors { get; }
    }

    public interface IError
    {
        string Id { get; }
        string Source { get; }
        string Description { get; }
        string StackTrace { get; }
    }
}
