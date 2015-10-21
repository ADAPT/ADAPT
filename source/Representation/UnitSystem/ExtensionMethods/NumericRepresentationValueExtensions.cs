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

using AgGateway.ADAPT.ApplicationDataModel;

namespace AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods
{
    public static class NumericRepresentationValueExtensions
    {
        public static void SetTarget(this NumericRepresentationValue numericRepresentationValue, UnitOfMeasure targetUom)
        {
            numericRepresentationValue.Value.ConvertToUnit(targetUom);
        }

        public static void SubtractFromSource(this NumericRepresentationValue numericRepresentationValue, NumericalValue secondNumber)
        {
            numericRepresentationValue.Value.SubtractFromSource(secondNumber);
        }

        public static void SubtractFromSource(this NumericRepresentationValue numericRepresentationValue, NumericRepresentationValue secondNumber)
        {
            numericRepresentationValue.Value.SubtractFromSource(secondNumber.Value);
        }

        public static NumericRepresentationValue Add(this NumericRepresentationValue numericRepresentationValue, double number)
        {
            var sum = numericRepresentationValue.Value.Add(number);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, sum);
        }

        public static void AddToSource(this NumericRepresentationValue numericRepresentationValue, double number)
        {
            numericRepresentationValue.Value.AddToSource(number);
        }

        public static NumericRepresentationValue Add(this NumericRepresentationValue numericRepresentationValue, NumericalValue secondNumber)
        {
            var sum = numericRepresentationValue.Value.Add(secondNumber);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, sum);
        }

        public static void AddToSource(this NumericRepresentationValue numericRepresentationValue, NumericalValue secondNumber)
        {
            numericRepresentationValue.Value.AddToSource(secondNumber);
        }

        public static void AddToSource(this NumericRepresentationValue numericRepresentationValue, NumericRepresentationValue secondNumber)
        {
            numericRepresentationValue.Value.AddToSource(secondNumber.Value);
        }

        public static NumericRepresentationValue Add(this NumericRepresentationValue numericRepresentationValue, NumericRepresentationValue secondNumber)
        {
            var sum = numericRepresentationValue.Value.Add(secondNumber.Value);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, sum);
        }

        public static NumericRepresentationValue Subtract(this NumericRepresentationValue numericRepresentationValue, double number)
        {
            var difference = numericRepresentationValue.Value.Subtract(number);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, difference);
        }

        public static void SubtractFromSource(this NumericRepresentationValue numericRepresentationValue, double number)
        {
            numericRepresentationValue.Value.SubtractFromSource(number);
        }

        public static NumericRepresentationValue Subtract(this NumericRepresentationValue numericRepresentationValue, NumericRepresentationValue secondNumber)
        {
            var difference = numericRepresentationValue.Value.Subtract(secondNumber.Value);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, difference);
        }

        public static NumericRepresentationValue Subtract(this NumericRepresentationValue numericRepresentationValue, NumericalValue secondNumber)
        {
            var difference = numericRepresentationValue.Value.Subtract(secondNumber);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, difference);
        }

        public static NumericRepresentationValue Divide(this NumericRepresentationValue numericRepresentationValue, double denominator)
        {
            var quotient = numericRepresentationValue.Value.Divide(denominator);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, quotient);
        }

        public static NumericRepresentationValue Divide(this NumericRepresentationValue numericRepresentationValue, NumericalValue denominator)
        {
            var quotient = numericRepresentationValue.Value.Divide(denominator);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, quotient);
        }

        public static NumericRepresentationValue Divide(this NumericRepresentationValue numericRepresentationValue, NumericRepresentationValue denominator, NumericRepresentation variableRepresentation)
        {
            var quotient = numericRepresentationValue.Value.Divide(denominator.Value);
            return new NumericRepresentationValue(variableRepresentation, quotient);
        }

        public static NumericRepresentationValue Divide(this NumericRepresentationValue numericRepresentationValue, NumericRepresentationValue denominator)
        {
            var quotient = numericRepresentationValue.Value.Divide(denominator.Value);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, quotient);
        }

        public static NumericRepresentationValue Multiply(this NumericRepresentationValue numericRepresentationValue, double right)
        {
            var product = numericRepresentationValue.Value.Multiply(right);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, product);
        }

        public static NumericRepresentationValue Multiply(this NumericRepresentationValue numericRepresentationValue, NumericalValue right)
        {
            var product = numericRepresentationValue.Value.Multiply(right);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, product);
        }

        public static NumericRepresentationValue Multiply(this NumericRepresentationValue numericRepresentationValue, NumericRepresentationValue right)
        {
            var product = numericRepresentationValue.Value.Multiply(right.Value);
            return new NumericRepresentationValue(numericRepresentationValue.Representation, product);
        }

        public static NumericRepresentationValue Multiply(this NumericRepresentationValue numericRepresentationValue, NumericRepresentationValue right, NumericRepresentation variableRepresentation)
        {
            var product = numericRepresentationValue.Multiply(right);
            return new NumericRepresentationValue(variableRepresentation, product.Value);
        }

        public static NumericRepresentationValue Copy(this NumericRepresentationValue value)
        {
            return new NumericRepresentationValue(value.Representation, value.UserProvidedUnitOfMeasure, value.Value);
        }
    }
}
