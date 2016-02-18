using System;
using AgGateway.ADAPT.ApplicationDataModel.Common;

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
            var unitDimensionId = uom.UnitDimension != null ? uom.UnitDimension.DomainID.TrimStart(new []{'u','t'}) : null;
            if (unitDimensionId != null)
            {
                var adaptUnitDimension = (UnitOfMeasureDimensionEnum) Enum.Parse(typeof (UnitOfMeasureDimensionEnum), unitDimensionId);
                unitOfMeasure.Dimension = adaptUnitDimension;
            }
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
