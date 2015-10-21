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
        public UnitOfMeasure SourceUnitOfMeasure { get; private set; }
        public double SourceValue { get; set; }

        public UnitOfMeasure TargetUnitOfMeasure { get; private set; }

        public double TargetValue
        {
            get { return _converter.Convert(SourceUnitOfMeasure, TargetUnitOfMeasure, SourceValue); }
        }

        public BaseNumber(string sourceUom, double value)
            : this(UnitSystemManager.Instance.UnitOfMeasures[sourceUom], value)
        {
            
        }

        public BaseNumber(UnitOfMeasure sourceUom, double value)
            : this(sourceUom, value, UnitOfMeasureConverter.Create())
        {
            
        }

        public BaseNumber(UnitOfMeasure sourceUom, double value, IUnitOfMeasureConverter converter)
        {
            _converter = converter;
            SourceUnitOfMeasure = sourceUom;
            SourceValue = value;
            SetTarget(sourceUom);
        }

        public void SetTarget(UnitOfMeasure targetUom)
        {
            if (targetUom == null)
                throw new ArgumentNullException("targetUom");

            TargetUnitOfMeasure = targetUom;
        }

        public BaseNumber Add(BaseNumber secondNumber)
        {
            secondNumber.SetTarget(SourceUnitOfMeasure);
            return new BaseNumber(SourceUnitOfMeasure, SourceValue + secondNumber.TargetValue);
        }

        public void AddToSource(BaseNumber secondNumber)
        {
            if (secondNumber != null)
            {
                secondNumber.SetTarget(SourceUnitOfMeasure);
                SourceValue += secondNumber.TargetValue;
            }
        }

        public BaseNumber Subtract(BaseNumber secondNumber)
        {
            secondNumber.SetTarget(SourceUnitOfMeasure);
            return new BaseNumber(SourceUnitOfMeasure, SourceValue - secondNumber.TargetValue);
        }

        public void SubtractFromSource(BaseNumber secondNumber)
        {
            if (secondNumber != null)
            {
                secondNumber.SetTarget(SourceUnitOfMeasure);
                SourceValue -= secondNumber.TargetValue;                
            }
        }

        public BaseNumber Add(double number)
        {
            return new BaseNumber(SourceUnitOfMeasure, SourceValue + number);
        }

        public void AddToSource(double number)
        {
            SourceValue += number;
        }

        public BaseNumber Subtract(double number)
        {
            return new BaseNumber(SourceUnitOfMeasure, SourceValue - number);
        }

        public void SubtractFromSource(double number)
        {
            SourceValue -= number;
        }

        public BaseNumber Divide(double denominator)
        {
            if (denominator == 0.0)
                throw new DivideByZeroException();

            return new BaseNumber(SourceUnitOfMeasure, SourceValue / denominator);
        }

        public BaseNumber Divide(BaseNumber denominator)
        {
            if(_baseNumberDivision == null)
                _baseNumberDivision = new BaseNumberDivision(_converter);

            return _baseNumberDivision.Divide(this, denominator);
        }

        public BaseNumber Multiply(double right)
        {
            return new BaseNumber(SourceUnitOfMeasure, SourceValue * right);
        }

        public BaseNumber Multiply(BaseNumber right)
        {
            if(_baseNumberMultiplication == null)
                _baseNumberMultiplication = new BaseNumberMultiplication(_converter);

            return _baseNumberMultiplication.Multiply(this, right);
        }
    }
}
