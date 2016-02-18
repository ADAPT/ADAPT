using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers
{
    public class RasterData<Rep,Val> where Rep : Representation
    {
        public Rep Representation { get; set; }

        public Val[,] Values { get; set; }
    }
}
