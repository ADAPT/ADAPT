namespace AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods
{
    public static class UnitOfMeasureExtensions
    {
        public static ApplicationDataModel.Common.UnitOfMeasure ToModelUom(this UnitOfMeasure uom)
        {
            var unitOfMeasure = new ApplicationDataModel.Common.UnitOfMeasure
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

        public static UnitOfMeasure ToInternalUom(this ApplicationDataModel.Common.UnitOfMeasure uom)
        {
            return InternalUnitSystemManager.Instance.UnitOfMeasures[uom.Code];
        }
    }
}
