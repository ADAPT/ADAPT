namespace AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods
{
    public static class UnitOfMeasureExtensions
    {
        public static ApplicationDataModel.UnitOfMeasure ToModelUom(this UnitOfMeasure uom)
        {
            var unitOfMeasure = new ApplicationDataModel.UnitOfMeasure
            {
                Code = uom.DomainID,
            };
            var scalarUom = uom as ScalarUnitOfMeasure;
            if (scalarUom != null)
            {
                unitOfMeasure.Scale = scalarUom.Scale;
                unitOfMeasure.Offset = scalarUom.BaseOffset;
            }
            return unitOfMeasure;
        }

        public static UnitOfMeasure ToInternalUom(this ApplicationDataModel.UnitOfMeasure uom)
        {
            return UnitSystemManager.Instance.UnitOfMeasures[uom.Code];
        }
    }
}
