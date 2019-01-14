using System.IO;
using System.Reflection;

namespace AgGateway.ADAPT.Representation
{
  internal static class ResourceManager
  {
    internal static Stream GetResourceStream(string fileName)
    {
      return Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format("AgGateway.ADAPT.Representation.Resources.{0}", fileName));
    }
  }
}
