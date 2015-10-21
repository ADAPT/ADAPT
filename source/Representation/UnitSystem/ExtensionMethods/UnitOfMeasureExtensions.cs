namespace AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods
{
    public static class UnitOfMeasureExtensions
    {
        public static ApplicationDataModel.UnitOfMeasure ToModelUom(this UnitOfMeasure uom)
        {
            var unitOfMeasure = new ApplicationDataModel.UnitOfMeasure
            {
                Code = uom.DomainID,
                Name = uom.Label,
                Symbol = uom.Label
            };
            var scalarUom = uom as ScalarUnitOfMeasure;
            if (scalarUom != null)
            {
                unitOfMeasure.ConversionScale = scalarUom.Scale;
                unitOfMeasure.ConversionOffset = scalarUom.BaseOffset;
            }
            return unitOfMeasure;
        }

        public static UnitOfMeasure ToInternalUom(this ApplicationDataModel.UnitOfMeasure uom)
        {
            return UnitSystemManager.Instance.UnitOfMeasures[uom.Code];
        }
    }
}
