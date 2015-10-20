namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class ProductMixComponent
    {
        public int ProductMixId { get; set; }

        public Product Component { get; set; }

        public NumericRepresentationValue Amount { get; set; }

        public bool IsCarrier { get; set; }
    }
}
