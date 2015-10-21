/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *******************************************************************************/

using System;
using System.Collections.Generic;

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public interface IUnitOfMeasureConverter
    {
        double Convert(UnitOfMeasure sourceUom, UnitOfMeasure targetUom, double sourceValue);
    }

    public class UnitOfMeasureConverter : IUnitOfMeasureConverter
    {
        public double Convert(UnitOfMeasure sourceUom, UnitOfMeasure targetUom, double sourceValue)
        {
            var scalarSource = sourceUom as ScalarUnitOfMeasure;
            var scalarTarget = targetUom as ScalarUnitOfMeasure;

            if (scalarSource != null)
            {
                if(scalarTarget != null)
                    return Convert(scalarSource, scalarTarget, sourceValue);
                return Convert(scalarSource, (CompositeUnitOfMeasure) targetUom, sourceValue);
            }
            if (scalarTarget != null)
                return Convert((CompositeUnitOfMeasure) sourceUom, scalarTarget, sourceValue);
            return Convert((CompositeUnitOfMeasure) sourceUom, (CompositeUnitOfMeasure) targetUom, sourceValue);
        }

        private double Convert(ScalarUnitOfMeasure sourceUom, ScalarUnitOfMeasure targetUom, double sourceValue)
        {
            CheckIfUnitsAreTheSameType(sourceUom, targetUom);

            return (sourceValue * sourceUom.Scale + sourceUom.BaseOffset - targetUom.BaseOffset) / targetUom.Scale;
        }

        private static void CheckIfUnitsAreTheSameType(ScalarUnitOfMeasure sourceUom, ScalarUnitOfMeasure targetUom)
        {
            if(sourceUom.UnitType.DomainID != targetUom.UnitType.DomainID)
                throw new InvalidOperationException("Cannot convert between units of different types.");
        }

        private double Convert(ScalarUnitOfMeasure sourceUom, CompositeUnitOfMeasure targetUom, double sourceValue)
        {
            foreach (var conversionFactor in sourceUom.UnitType.CompositeEquivalents)
            {
                var compositeSourceValue = (sourceValue * sourceUom.Scale + sourceUom.BaseOffset - conversionFactor.BaseOffset) / conversionFactor.Scale;
                var compositeSourceUom = new CompositeUnitOfMeasure(conversionFactor.DomainID);
                return Convert(compositeSourceUom, targetUom, compositeSourceValue);
            }
            throw new InvalidOperationException("Cannot convert between units of different types.");
        }

        private double Convert(CompositeUnitOfMeasure sourceUom, ScalarUnitOfMeasure targetUom, double sourceValue)
        {
            foreach (var conversionFactor in targetUom.UnitType.CompositeEquivalents)
            {
                var compositeSourceValue = (sourceValue * conversionFactor.Scale + conversionFactor.BaseOffset - targetUom.BaseOffset) / targetUom.Scale;
                var compositeTargetUom = new CompositeUnitOfMeasure(conversionFactor.DomainID);
                return Convert(sourceUom, compositeTargetUom, compositeSourceValue);
            }
            throw new InvalidOperationException("Cannot convert between units of different types.");
        }

        private double Convert(CompositeUnitOfMeasure sourceUom, CompositeUnitOfMeasure targetUom, double sourceValue)
        {
            if (sourceUom.DomainID == targetUom.DomainID)
                return sourceValue;
            var conversionScalar = RecurseComponents(sourceUom.Components, targetUom.Components, 1.0);
            return sourceValue * conversionScalar;
        }

        private double RecurseComponents(List<UnitOfMeasureComponent> sourceComponents, List<UnitOfMeasureComponent> targetComponents, double sourceValue)
        {
            double targetValue = 1;
            for (int i = 0; i < sourceComponents.Count; ++i)
            {
                var source = sourceComponents[i];
                var target = targetComponents[i];
                if (source.DomainID == target.DomainID)
                    continue;

                var baseValue = Convert(source.Unit, target.Unit, sourceValue);

                if (Math.Abs(baseValue) < double.Epsilon && source.Power < 0)
                    targetValue *= 0;
                else
                    targetValue *= Math.Pow(baseValue, source.Power);
            }
            return targetValue;
        }
    }
}