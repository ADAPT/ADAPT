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
    public class VariableNumber : INumber, ICopy<VariableNumber>
    {
        private readonly INumber _baseNumber;
        private readonly IUnitOfMeasureConverter _converter;

        public VariableRepresentation Representation
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

        public VariableNumber(VariableRepresentation representation, UnitOfMeasure unitOfMeasure, double value)
            : this(representation, unitOfMeasure, value, UnitOfMeasureConverter.Create())
        {

        }

        public VariableNumber(VariableRepresentation representation, UnitOfMeasure unitOfMeasure, double value, IUnitOfMeasureConverter converter)
            : this(representation, new BaseNumber(unitOfMeasure, value, converter), converter)
        {
            
        }

        public VariableNumber(int representationTag, UnitOfMeasure uom, double value) :
            this((VariableRepresentation)RepresentationManager.Instance.Representations[representationTag], uom, value)
        {
        }

        public VariableNumber(int representationTag, string uomDomainId, double value) :
            this((VariableRepresentation)RepresentationManager.Instance.Representations[representationTag], UnitSystemManager.Instance.UnitOfMeasures[uomDomainId], value)
        {
        }

        private VariableNumber(VariableRepresentation representation, INumber number, IUnitOfMeasureConverter converter)
        {
            _baseNumber = number;
            _converter = converter;
            Representation = representation;
        }

        public void SetTarget(UnitOfMeasure targetUom)
        {
            _baseNumber.SetTarget(targetUom);
        }

        public void SubtractFromSource(INumber secondNumber)
        {
            _baseNumber.SubtractFromSource(secondNumber);
        }

        public INumber Add(double number)
        {
            var sum = _baseNumber.Add(number);
            return new VariableNumber(Representation, sum, _converter);
        }

        public void AddToSource(double number)
        {
            _baseNumber.AddToSource(number);
        }

        public INumber Add(INumber secondNumber)
        {
            var sum = _baseNumber.Add(secondNumber);
            return new VariableNumber(Representation, sum, _converter);
        }

        public void AddToSource(INumber secondNumber)
        {
            _baseNumber.AddToSource(secondNumber);
        }

        public VariableNumber Add(VariableNumber secondNumber)
        {
            var sum = _baseNumber.Add(secondNumber);
            return new VariableNumber(Representation, sum, _converter);
        }

        public INumber Subtract(double number)
        {
            var difference = _baseNumber.Subtract(number);
            return new VariableNumber(Representation, difference, _converter);
        }

        public void SubtractFromSource(double number)
        {
            _baseNumber.SubtractFromSource(number);
        }

        public INumber Subtract(INumber secondNumber)
        {
            var difference = _baseNumber.Subtract(secondNumber);
            return new VariableNumber(Representation, difference, _converter);
        }

        public VariableNumber Subtract(VariableNumber secondNumber)
        {
            var difference = _baseNumber.Subtract(secondNumber);
            return new VariableNumber(Representation, difference, _converter);
        }

        public INumber Divide(double denominator)
        {
            var quotient = _baseNumber.Divide(denominator);
            return new VariableNumber(Representation, quotient, _converter);
        }

        public INumber Divide(INumber denominator)
        {
            var quotient = _baseNumber.Divide(denominator);
            return new VariableNumber(Representation, quotient, _converter);
        }

        public VariableNumber Divide(VariableNumber denominator, VariableRepresentation variableRepresentation)
        {
            var quotient = _baseNumber.Divide(denominator);
            return new VariableNumber(variableRepresentation, quotient, _converter);
        }

        public INumber Multiply(double right)
        {
            var product = _baseNumber.Multiply(right);
            return new VariableNumber(Representation, product, _converter);
        }

        public INumber Multiply(INumber right)
        {
            var product = _baseNumber.Multiply(right);
            return new VariableNumber(Representation, product, _converter);
        }

        public VariableNumber Multiply(VariableNumber right, VariableRepresentation variableRepresentation)
        {
            var product = Multiply(right);
            return new VariableNumber(variableRepresentation, product, _converter);
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
