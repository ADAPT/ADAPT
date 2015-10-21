/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Joe Ross, Tim Shearouse - initial API and implementation
  *******************************************************************************/

using System;
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.Representation.UnitSystem.UnitArithmatic;

namespace AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods
{
    public static class NumericalValueExtensions
    {
        public static void SubtractFromSource(this NumericalValue numericalValue, double number)
        {
            numericalValue.Value -= number;
        }

        public static NumericalValue Divide(this NumericalValue numericalValue, double denominator)
        {
            if (denominator == 0.0)
                throw new DivideByZeroException();

            return new NumericalValue(numericalValue.UnitOfMeasure, numericalValue.Value / denominator);
        }

        public static NumericalValue Subtract(this NumericalValue numericalValue, double number)
        {
            return new NumericalValue(numericalValue.UnitOfMeasure, numericalValue.Value - number);
        }

        public static NumericalValue Add(this NumericalValue numericalValue, double number)
        {
            return new NumericalValue(numericalValue.UnitOfMeasure, numericalValue.Value + number);
        }

        public static void AddToSource(this NumericalValue numericalValue, double number)
        {
            numericalValue.Value += number;
        }

        public static NumericalValue Multiply(this NumericalValue numericalValue, double right)
        {
            return new NumericalValue(numericalValue.UnitOfMeasure, numericalValue.Value * right);
        }

        public static NumericalValue Multiply(this NumericalValue numericalValue, NumericalValue right)
        {
            return BaseNumberMultiplication.Multiply(numericalValue, right);
        }

        public static NumericalValue Divide(this NumericalValue numericalValue, NumericalValue denominator)
        {
            return BaseNumberDivision.Divide(numericalValue, denominator);
        }

        public static NumericalValue Subtract(this NumericalValue numericalValue, NumericalValue secondNumber)
        {
            var unitOfMeasure = numericalValue.UnitOfMeasure.ToInternalUom();
            return new NumericalValue(numericalValue.UnitOfMeasure, numericalValue.Value - secondNumber.ConvertToUnit(unitOfMeasure));
        }

        public static void SubtractFromSource(this NumericalValue numericalValue, NumericalValue secondNumber)
        {
            if (secondNumber != null)
            {
                numericalValue.Value -= secondNumber.ConvertToUnit(numericalValue.UnitOfMeasure.ToInternalUom());
            }
        }

        public static NumericalValue Add(this NumericalValue numericalValue, NumericalValue secondNumber)
        {
            var unitOfMeasure = numericalValue.UnitOfMeasure.ToInternalUom();
            return new NumericalValue(numericalValue.UnitOfMeasure, numericalValue.Value + secondNumber.ConvertToUnit(unitOfMeasure));
        }

        public static void AddToSource(this NumericalValue numericalValue, NumericalValue secondNumber)
        {
            if (secondNumber != null)
            {
                numericalValue.Value += secondNumber.ConvertToUnit(numericalValue.UnitOfMeasure.ToInternalUom());
            }
        }

        public static double ConvertToUnit(this NumericalValue numericalValue, UnitOfMeasure targetUom)
        {
            if (targetUom == null)
                throw new ArgumentNullException("targetUom");

            var unitOfMeasure = numericalValue.UnitOfMeasure;
            var internalUnit = UnitSystemManager.Instance.UnitOfMeasures[unitOfMeasure.Code];
            numericalValue.Value = new UnitOfMeasureConverter().Convert(internalUnit, targetUom, numericalValue.Value);
            numericalValue.UnitOfMeasure = targetUom.ToModelUom();
            return numericalValue.Value;
        }
    }
}
