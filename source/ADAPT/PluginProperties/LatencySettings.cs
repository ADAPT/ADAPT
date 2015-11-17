namespace AgGateway.ADAPT.ApplicationDataModel.PluginProperties
{
    public class LatencySettings
    {
        public double RecordingOnTransitionDelay { get; set; }
        public double RecordingOffTransitionDelay { get; set; }
        public double HarvestYieldDelay { get; set; }
        public double HarvestMoistureDelay { get; set; }
        public double ForageYieldDelay { get; set; }
        public double ForageMoistureDelay { get; set; }
        public bool ApplyLatency { get; set; }
        public bool DisperseYield { get; set; }
    }
}
