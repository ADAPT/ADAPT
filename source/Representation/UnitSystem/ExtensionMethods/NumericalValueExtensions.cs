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
        public static void SubtractFromSource(this NumericValue numericValue, double number)
        {
            numericValue.Value -= number;
        }

        public static NumericValue Divide(this NumericValue numericValue, double denominator)
        {
            if (denominator == 0.0)
                throw new DivideByZeroException();

            return new NumericValue(numericValue.UnitOfMeasure, numericValue.Value / denominator);
        }

        public static NumericValue Subtract(this NumericValue numericValue, double number)
        {
            return new NumericValue(numericValue.UnitOfMeasure, numericValue.Value - number);
        }

        public static NumericValue Add(this NumericValue numericValue, double number)
        {
            return new NumericValue(numericValue.UnitOfMeasure, numericValue.Value + number);
        }

        public static void AddToSource(this NumericValue numericValue, double number)
        {
            numericValue.Value += number;
        }

        public static NumericValue Multiply(this NumericValue numericValue, double right)
        {
            return new NumericValue(numericValue.UnitOfMeasure, numericValue.Value * right);
        }

        public static NumericValue Multiply(this NumericValue numericValue, NumericValue right)
        {
            return BaseNumberMultiplication.Multiply(numericValue, right);
        }

        public static NumericValue Divide(this NumericValue numericValue, NumericValue denominator)
        {
            return BaseNumberDivision.Divide(numericValue, denominator);
        }

        public static NumericValue Subtract(this NumericValue numericValue, NumericValue secondNumber)
        {
            var unitOfMeasure = numericValue.UnitOfMeasure.ToInternalUom();
            return new NumericValue(numericValue.UnitOfMeasure, numericValue.Value - secondNumber.ConvertToUnit(unitOfMeasure));
        }

        public static void SubtractFromSource(this NumericValue numericValue, NumericValue secondNumber)
        {
            if (secondNumber != null)
            {
                numericValue.Value -= secondNumber.ConvertToUnit(numericValue.UnitOfMeasure.ToInternalUom());
            }
        }

        public static NumericValue Add(this NumericValue numericValue, NumericValue secondNumber)
        {
            var unitOfMeasure = numericValue.UnitOfMeasure.ToInternalUom();
            return new NumericValue(numericValue.UnitOfMeasure, numericValue.Value + secondNumber.ConvertToUnit(unitOfMeasure));
        }

        public static void AddToSource(this NumericValue numericValue, NumericValue secondNumber)
        {
            if (secondNumber != null)
            {
                numericValue.Value += secondNumber.ConvertToUnit(numericValue.UnitOfMeasure.ToInternalUom());
            }
        }

        public static double ConvertToUnit(this NumericValue numericValue, UnitOfMeasure targetUom)
        {
            if (targetUom == null)
                throw new ArgumentNullException("targetUom");

            var unitOfMeasure = numericValue.UnitOfMeasure;
            var internalUnit = InternalUnitSystemManager.Instance.UnitOfMeasures[unitOfMeasure.Code];
            numericValue.Value = new UnitOfMeasureConverter().Convert(internalUnit, targetUom, numericValue.Value);
            numericValue.UnitOfMeasure = targetUom.ToModelUom();
            return numericValue.Value;
        }
    }
}
