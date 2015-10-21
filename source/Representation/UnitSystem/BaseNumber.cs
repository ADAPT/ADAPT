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
using AgGateway.ADAPT.Representation.UnitSystem.UnitArithmatic;

namespace AgGateway.ADAPT.Representation.UnitSystem
{

    public class BaseNumber 
    {
        private readonly IUnitOfMeasureConverter _converter;
        private BaseNumberDivision _baseNumberDivision;
        private BaseNumberMultiplication _baseNumberMultiplication;
        public UnitOfMeasure UnitOfMeasure { get; private set; }
        public double Value { get; set; }

        public BaseNumber(string sourceUom, double value)
            : this(UnitSystemManager.Instance.UnitOfMeasures[sourceUom], value)
        {
            
        }

        public BaseNumber(UnitOfMeasure uom, double value)
            : this(uom, value, UnitOfMeasureConverter.Create())
        {
            
        }

        public BaseNumber(UnitOfMeasure uom, double value, IUnitOfMeasureConverter converter)
        {
            _converter = converter;
            UnitOfMeasure = uom;
            Value = value;
        }

        public double ConvertToUnit(UnitOfMeasure targetUom)
        {
            if (targetUom == null)
                throw new ArgumentNullException("targetUom");

            Value = _converter.Convert(UnitOfMeasure, targetUom, Value);
            UnitOfMeasure = targetUom;
            return Value;
        }

        public BaseNumber Add(BaseNumber secondNumber)
        {
            return new BaseNumber(UnitOfMeasure, Value + secondNumber.ConvertToUnit(UnitOfMeasure));
        }

        public void AddToSource(BaseNumber secondNumber)
        {
            if (secondNumber != null)
            {
                Value += secondNumber.ConvertToUnit(UnitOfMeasure);
            }
        }

        public BaseNumber Subtract(BaseNumber secondNumber)
        {
            return new BaseNumber(UnitOfMeasure, Value - secondNumber.ConvertToUnit(UnitOfMeasure));
        }

        public void SubtractFromSource(BaseNumber secondNumber)
        {
            if (secondNumber != null)
            {
                Value -= secondNumber.ConvertToUnit(UnitOfMeasure);                
            }
        }

        public BaseNumber Add(double number)
        {
            return new BaseNumber(UnitOfMeasure, Value + number);
        }

        public void AddToSource(double number)
        {
            Value += number;
        }

        public BaseNumber Subtract(double number)
        {
            return new BaseNumber(UnitOfMeasure, Value - number);
        }

        public void SubtractFromSource(double number)
        {
            Value -= number;
        }

        public BaseNumber Divide(double denominator)
        {
            if (denominator == 0.0)
                throw new DivideByZeroException();

            return new BaseNumber(UnitOfMeasure, Value / denominator);
        }

        public BaseNumber Divide(BaseNumber denominator)
        {
            if(_baseNumberDivision == null)
                _baseNumberDivision = new BaseNumberDivision(_converter);

            return _baseNumberDivision.Divide(this, denominator);
        }

        public BaseNumber Multiply(double right)
        {
            return new BaseNumber(UnitOfMeasure, Value * right);
        }

        public BaseNumber Multiply(BaseNumber right)
        {
            if(_baseNumberMultiplication == null)
                _baseNumberMultiplication = new BaseNumberMultiplication(_converter);

            return _baseNumberMultiplication.Multiply(this, right);
        }
    }
}
