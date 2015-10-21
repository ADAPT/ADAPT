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

using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.Representation.RepresentationSystem;

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public class VariableNumber : ICopy<VariableNumber>
    {
        private readonly BaseNumber _baseNumber;
        private readonly IUnitOfMeasureConverter _converter;

        public NumericRepresentation Representation
        {
            get;
            private set;
        }

        public UnitOfMeasure SourceUnitOfMeasure
        {
            get
            {
                return _baseNumber.SourceUnitOfMeasure;
            }
        }

        public double SourceValue
        {
            get
            {
                return _baseNumber.SourceValue;
            }
            set
            {
                _baseNumber.SourceValue = value;
            }
        }

        public UnitOfMeasure TargetUnitOfMeasure
        {
            get
            {
                return _baseNumber.TargetUnitOfMeasure;
            }
        }

        public double TargetValue
        {
            get
            {
                return _baseNumber.TargetValue;
            }
        }

        public VariableNumber(NumericRepresentation representation, UnitOfMeasure unitOfMeasure, double value)
            : this(representation, unitOfMeasure, value, UnitOfMeasureConverter.Create())
        {

        }

        public VariableNumber(NumericRepresentation representation, UnitOfMeasure unitOfMeasure, double value, IUnitOfMeasureConverter converter)
            : this(representation, new BaseNumber(unitOfMeasure, value, converter), converter)
        {
            
        }

        public VariableNumber(int representationTag, UnitOfMeasure uom, double value) :
            this((NumericRepresentation)RepresentationManager.Instance.Representations[representationTag], uom, value)
        {
        }

        public VariableNumber(int representationTag, string uomDomainId, double value) :
            this((NumericRepresentation)RepresentationManager.Instance.Representations[representationTag], UnitSystemManager.Instance.UnitOfMeasures[uomDomainId], value)
        {
        }

        private VariableNumber(NumericRepresentation representation, BaseNumber number, IUnitOfMeasureConverter converter)
        {
            _baseNumber = number;
            _converter = converter;
            Representation = representation;
        }

        public void SetTarget(UnitOfMeasure targetUom)
        {
            _baseNumber.SetTarget(targetUom);
        }

        public void SubtractFromSource(BaseNumber secondNumber)
        {
            _baseNumber.SubtractFromSource(secondNumber);
        }

        public void SubtractFromSource(VariableNumber secondNumber)
        {
            _baseNumber.SubtractFromSource(secondNumber._baseNumber);
        }

        public VariableNumber Add(double number)
        {
            var sum = _baseNumber.Add(number);
            return new VariableNumber(Representation, sum, _converter);
        }

        public void AddToSource(double number)
        {
            _baseNumber.AddToSource(number);
        }

        public VariableNumber Add(BaseNumber secondNumber)
        {
            var sum = _baseNumber.Add(secondNumber);
            return new VariableNumber(Representation, sum, _converter);
        }

        public void AddToSource(BaseNumber secondNumber)
        {
            _baseNumber.AddToSource(secondNumber);
        }

        public void AddToSource(VariableNumber secondNumber)
        {
            _baseNumber.AddToSource(secondNumber._baseNumber);
        }

        public VariableNumber Add(VariableNumber secondNumber)
        {
            var sum = _baseNumber.Add(secondNumber._baseNumber);
            return new VariableNumber(Representation, sum, _converter);
        }

        public VariableNumber Subtract(double number)
        {
            var difference = _baseNumber.Subtract(number);
            return new VariableNumber(Representation, difference, _converter);
        }

        public void SubtractFromSource(double number)
        {
            _baseNumber.SubtractFromSource(number);
        }

        public VariableNumber Subtract(VariableNumber secondNumber)
        {
            var difference = _baseNumber.Subtract(secondNumber._baseNumber);
            return new VariableNumber(Representation, difference, _converter);
        }

        public VariableNumber Subtract(BaseNumber secondNumber)
        {
            var difference = _baseNumber.Subtract(secondNumber);
            return new VariableNumber(Representation, difference, _converter);
        }

        public VariableNumber Divide(double denominator)
        {
            var quotient = _baseNumber.Divide(denominator);
            return new VariableNumber(Representation, quotient, _converter);
        }

        public VariableNumber Divide(BaseNumber denominator)
        {
            var quotient = _baseNumber.Divide(denominator);
            return new VariableNumber(Representation, quotient, _converter);
        }

        public VariableNumber Divide(VariableNumber denominator)
        {
            var quotient = _baseNumber.Divide(denominator._baseNumber);
            return new VariableNumber(Representation, quotient, _converter);
        }

        public VariableNumber Divide(VariableNumber denominator, NumericRepresentation variableRepresentation)
        {
            var quotient = _baseNumber.Divide(denominator._baseNumber);
            return new VariableNumber(variableRepresentation, quotient, _converter);
        }

        public VariableNumber Multiply(double right)
        {
            var product = _baseNumber.Multiply(right);
            return new VariableNumber(Representation, product, _converter);
        }

        public VariableNumber Multiply(BaseNumber right)
        {
            var product = _baseNumber.Multiply(right);
            return new VariableNumber(Representation, product, _converter);
        }

        public VariableNumber Multiply(VariableNumber right)
        {
            var product = _baseNumber.Multiply(right._baseNumber);
            return new VariableNumber(Representation, product, _converter);
        }

        public VariableNumber Multiply(VariableNumber right, NumericRepresentation variableRepresentation)
        {
            var product = Multiply(right);
            return new VariableNumber(variableRepresentation, product._baseNumber, _converter);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2})", SourceValue, SourceUnitOfMeasure.DomainID, Representation.Name);
        }

        public VariableNumber Copy()
        {
            return new VariableNumber(Representation, SourceUnitOfMeasure, SourceValue);
        }
    }
}
