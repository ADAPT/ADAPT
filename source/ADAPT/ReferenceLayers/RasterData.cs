namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class RasterData<Rep,Val> where Rep : Representation
    {
        public Rep Representation { get; set; }

        public Val[,] Values { get; set; }
    }
}
