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
  *    Joseph Ross Renaming/Updating tests to acount for changes in the Numeric RepresentationValue Class
  *******************************************************************************/

using System;
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using AgGateway.ADAPT.Representation.RepresentationSystem.ExtensionMethods;
using AgGateway.ADAPT.Representation.UnitSystem;
using AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods;
using Moq;
using NUnit.Framework;
using UnitOfMeasure = AgGateway.ADAPT.Representation.UnitSystem.UnitOfMeasure;

namespace AgGateway.ADAPT.RepresentationTest.UnitSystem
{
    [TestFixture]
    public class NumericRepresentationExtensionsTest
    {
        private UnitOfMeasure _ftUnitOfMeasure = InternalUnitSystemManager.Instance.UnitOfMeasures["ft"];
        private const double Epsilon = 0.005;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenRepresentationAndUomWhenCreateVariableNumberShouldSetRepAndUom()
        {
            var representation = RepresentationInstanceList.vrAirTemperature.ToModelRepresentation();
            var uom = InternalUnitSystemManager.Instance.UnitOfMeasures["C"].ToModelUom();
            var numericValue = new NumericValue(uom, 1.23);

            var numericRepresentationValue = new NumericRepresentationValue(representation, uom, numericValue);

            Assert.AreEqual(representation.Code, numericRepresentationValue.Representation.Code);
            Assert.AreEqual(uom.Code, numericRepresentationValue.UserProvidedUnitOfMeasure.Code);
        }

        [Test]
        public void GivenRepresentationAndUomIdWhenCreateVariableNumberShouldSetRepAndUom()
        {
            var representationTag = RepresentationInstanceList.vrAirTemperature.ToModelRepresentation();
            var uom = InternalUnitSystemManager.Instance.UnitOfMeasures["C"].ToModelUom();
            var numericValue = new NumericValue(uom, 1.23);

            var numericRepresentationValue = new NumericRepresentationValue(representationTag, numericValue);

            Assert.AreEqual(representationTag.Code, numericRepresentationValue.Representation.Code);
            Assert.AreEqual(uom.Code, numericRepresentationValue.Value.UnitOfMeasure.Code);
        }

        [Test]
        public void GivenSourceValueWhenCreatedThenSourceValue()
        {
            var representation = RepresentationInstanceList.vrAirTemperature.ToModelRepresentation();
            var uom = InternalUnitSystemManager.Instance.UnitOfMeasures["C"].ToModelUom();
            var numericValue = new NumericValue(uom, 5);

            var numericRepresentationValue = new NumericRepresentationValue(representation, numericValue);

            Assert.AreEqual(5, numericRepresentationValue.Value.Value);
        }


        [Test]
        public void GivenTwoVariableNumbersWithSameUomWhenAddedThenSourceValueIsSum()
        {
            var uom = InternalUnitSystemManager.Instance.UnitOfMeasures["C"].ToModelUom();
            var originalValue = new NumericValue(uom, 22);
            var originalRep = new NumericRepresentationValue(RepresentationInstanceList.vrAirTemperature.ToModelRepresentation(), originalValue);
            var secondNumber = new NumericValue(uom, 11);

            var result = originalRep.Add(secondNumber);
            Assert.IsInstanceOf<NumericRepresentationValue>(result);
            Assert.AreEqual(33, result.Value.Value);
        }

        [Test]
        public void GivenTwoVariableNumbersWhenAddedThenRepresentationIsOriginal()
        {
            var originalUom = _ftUnitOfMeasure.ToModelUom();
            var originalValue = new NumericValue(originalUom, 22);
            var originalNumber = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), originalValue);

            var secondUom = InternalUnitSystemManager.Instance.UnitOfMeasures["m"].ToModelUom();
            var secondValue = new NumericValue(secondUom, 11);
            var secondNumber = new NumericRepresentationValue(RepresentationInstanceList.vrElevation.ToModelRepresentation(), secondValue);

            var result = originalNumber.Add(secondNumber);
            Assert.AreSame(RepresentationInstanceList.vrDistanceTraveled.DomainId, result.Representation.Code);
        }

        [Test]
        public void GivenVariableNumberWhenAddVariableNumberThenResultIsInOriginalUom()
        {
            var originalUom = InternalUnitSystemManager.Instance.UnitOfMeasures["m"].ToModelUom();
            var originalValue = new NumericValue(originalUom, 1.75);
            var originalNumber = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), originalValue);

            var secondUom = _ftUnitOfMeasure.ToModelUom();
            var secondNumber = new NumericValue(secondUom, 3.5);

            var expected = 2.8168; //1.75m + (3.5ft -> m)
            var actual = originalNumber.Add(secondNumber);
            Assert.IsInstanceOf<NumericRepresentationValue>(actual);
            Assert.AreEqual(expected, actual.Value.Value, 0.005);
            Assert.AreSame(originalUom, actual.Value.UnitOfMeasure);
        }

        [Test]
        public void GivenVariableNumberWhenAddDoubleShouldReturnNewVariableNumberWithSourceAddedToDouble()
        {
            var uom = InternalUnitSystemManager.Instance.UnitOfMeasures["mi"].ToModelUom();
            var originalValue = new NumericValue(uom, 3.62);
            var number = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), originalValue);

            var result = number.Add(1.23);

            Assert.IsInstanceOf<NumericRepresentationValue>(result);
            Assert.AreEqual(4.85, result.Value.Value, Epsilon);
        }

        [Test]
        public void GivenVariableNumbersWithIncompatibleUnitsWhenAddThenException()
        {
            var originalUom = InternalUnitSystemManager.Instance.UnitOfMeasures["m"].ToModelUom();
            var originalValue = new NumericValue(originalUom, 1.75);
            var originalNumber = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), originalValue);

            var secondUom = InternalUnitSystemManager.Instance.UnitOfMeasures["C"].ToModelUom();
            var secondValue = new NumericValue(secondUom, 3.5);
            var secondNumber = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), secondValue);

            Assert.Throws<InvalidOperationException>(() => originalNumber.Add(secondNumber));
        }

        [Test]
        public void GivenTwoVariableNumbersWithSameUomWhenSubtractedThenSourceValueIsDifference()
        {
            var uom = InternalUnitSystemManager.Instance.UnitOfMeasures["C"].ToModelUom();
            var originalValue = new NumericValue(uom, 22);
            var originalNumber = new NumericRepresentationValue(RepresentationInstanceList.vrAirTemperature.ToModelRepresentation(), originalValue);
            var secondNumber = new NumericValue(uom, 13);

            var result = originalNumber.Subtract(secondNumber);
            Assert.IsInstanceOf<NumericRepresentationValue>(result);
            Assert.AreEqual(9, result.Value.Value);
        }

        [Test]
        public void GivenVariableNumberWhenSubtractVariableNumberThenResultIsInOriginalUom()
        {
            var originalUom = InternalUnitSystemManager.Instance.UnitOfMeasures["m"].ToModelUom();
            var originalValue = new NumericValue(originalUom, 1.75);
            var originalNumber = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(),  originalValue);

            var secondUom = _ftUnitOfMeasure.ToModelUom();
            var secondNumber = new NumericValue(secondUom, 3.5);

            var expected = 0.6832; //1.75m + (3.5ft -> m)
            var actual = originalNumber.Subtract(secondNumber);
            Assert.IsInstanceOf<NumericRepresentationValue>(actual);
            Assert.AreEqual(expected, actual.Value.Value, Epsilon);
            Assert.AreSame(originalUom, actual.Value.UnitOfMeasure);
        }

        [Test]
        public void GivenTwoVariableNubmersWhenSubtractedThenRepresentationIsOriginal()
        {
            var originalUom = _ftUnitOfMeasure.ToModelUom();
            var originalValue = new NumericValue(originalUom, 22);
            var originalNumber = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), originalValue);
            var secondUom = InternalUnitSystemManager.Instance.UnitOfMeasures["m"].ToModelUom();
            var secondValue = new NumericValue(secondUom, 11);
            var secondNumber = new NumericRepresentationValue(RepresentationInstanceList.vrElevation.ToModelRepresentation(), secondValue);

            var result = originalNumber.Subtract(secondNumber);
            Assert.AreSame(RepresentationInstanceList.vrDistanceTraveled.DomainId, result.Representation.Code);
        }

        [Test]
        public void GivenVariableNumbersWithIncompatibleUnitsWhenSubtractThenException()
        {
            var originalUom = InternalUnitSystemManager.Instance.UnitOfMeasures["m"].ToModelUom();
            var originalValue = new NumericValue(originalUom, 1.75);
            var originalNumber = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), originalValue);

            var secondUom = InternalUnitSystemManager.Instance.UnitOfMeasures["C"].ToModelUom();
            var secondValue = new NumericValue(secondUom, 3.5);
            var secondNumber = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), secondValue);

            Assert.Throws<InvalidOperationException>(() => originalNumber.Subtract(secondNumber));
        }

        [Test]
        public void GivenVariableNumberWhenSubtractDoubleShouldReturnNewVariableNumberWithDoubleSubtractedFromSource()
        {
            var uom = InternalUnitSystemManager.Instance.UnitOfMeasures["mi"].ToModelUom();
            var value = new NumericValue(uom, 3.62);
            var number = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), value);

            var result = number.Subtract(1.23);

            Assert.IsInstanceOf<NumericRepresentationValue>(result);
            Assert.AreEqual(2.39, result.Value.Value, Epsilon);
        }

        [Test]
        public void GivenVariableNumberWhenDivideDoubleThenSourceValueIsQuotient()
        {
            var uom = InternalUnitSystemManager.Instance.UnitOfMeasures["mi"].ToModelUom();
            var value = new NumericValue(uom, 3.62);
            var number = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), value);

            var result = number.Divide(1.23);

            Assert.IsInstanceOf<NumericRepresentationValue>(result);
            Assert.AreEqual(3.62 / 1.23, result.Value.Value, Epsilon);
        }

        [Test]
        public void GivenVariableNumberWhenDivideByZeroShouldThrowException()
        {
            var uom = InternalUnitSystemManager.Instance.UnitOfMeasures["mi"].ToModelUom();
            var value = new NumericValue(uom, 3.62);
            var number = new NumericRepresentationValue(RepresentationInstanceList.vrRoverDistance.ToModelRepresentation(), value);

            Assert.Throws<DivideByZeroException>(() => number.Divide(0));
        }

        [Test]
        public void GivenVariableNumberWhenDivideVariableNumberThenUnitOfMeasuresCombined()
        {
            var uom = _ftUnitOfMeasure.ToModelUom();
            var value = new NumericValue(uom, 12);
            var numerator = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), value);
            var denominator = new NumericValue(InternalUnitSystemManager.Instance.UnitOfMeasures["sec"].ToModelUom(), 5);

            var quotient = numerator.Divide(denominator);
            Assert.IsInstanceOf<NumericRepresentationValue>(quotient);
            Assert.AreEqual("ft1sec-1", quotient.Value.UnitOfMeasure.Code);
            Assert.AreEqual(2.4, quotient.Value.Value, Epsilon);
        }

        [Test]
        public void GivenVariableNumberWhenDivideNumberWithSameUnitThenSourceValueIsQuotient()
        {
            var uom = _ftUnitOfMeasure.ToModelUom();
            var value = new NumericValue(uom, 12);
            var numerator = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(),  value);
            var denominator = new NumericValue(_ftUnitOfMeasure.ToModelUom(), 6);

            var quotient = numerator.Divide(denominator);
            Assert.IsInstanceOf<NumericRepresentationValue>(quotient);
            Assert.AreEqual("ratio", quotient.Value.UnitOfMeasure.Code);
            Assert.AreEqual(2, quotient.Value.Value, Epsilon);
        }

        [Test]
        public void GivenVariableNumberWhenDivideVariableNumberWithZeroValueThenDivideByZeroException()
        {
            var numeratorUom = _ftUnitOfMeasure.ToModelUom();
            var numeratorValue = new NumericValue(numeratorUom, 3);
            var numerator = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), numeratorValue);
            var denominatorUom = InternalUnitSystemManager.Instance.UnitOfMeasures["sec"].ToModelUom();
            var denominatorValue = new NumericValue(denominatorUom, 0);
            var denominator = new NumericRepresentationValue(RepresentationInstanceList.vrDeltaTime.ToModelRepresentation(), denominatorValue);

            Assert.Throws<DivideByZeroException>(() => numerator.Divide(denominator, RepresentationInstanceList.vrVehicleSpeed.ToModelRepresentation()));
        }

        [Test]
        public void GivenVariableNunmberWithCompositeUnitOfMeasureWhenDivideVariableNumberThenUnitOfMeasuresCombined()
        {
            var numeratorUom = InternalUnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom();
            var numeratorValue = new NumericValue(numeratorUom, 2.4);
            var numerator = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), numeratorValue);
            var denominatorUom = InternalUnitSystemManager.Instance.UnitOfMeasures["sec"].ToModelUom();
            var denominatorValue = new NumericValue(denominatorUom, 5);
            var denominator = new NumericRepresentationValue(RepresentationInstanceList.vrDeltaTime.ToModelRepresentation(), denominatorValue);

            var quotient = numerator.Divide(denominator, RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation());
            Assert.AreEqual("ft1[sec2]-1", quotient.Value.UnitOfMeasure.Code);
            Assert.AreSame(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation().Code, quotient.Representation.Code);
            Assert.AreEqual(.48, quotient.Value.Value, Epsilon);
        }

        [Test]
        public void GivenVariableNumberWhenWhenDivideVariableNumberWithCompositeUnitOfMeasureThenUnitOfMeasuresSimplified()
        {
            var numeratorUom = _ftUnitOfMeasure.ToModelUom();
            var numeratorValue = new NumericValue(numeratorUom, 12.54);
            var numerator = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), numeratorValue);
            var denominatorUom = InternalUnitSystemManager.Instance.UnitOfMeasures["[sec2]-1"].ToModelUom();
            var denominatorValue = new NumericValue(denominatorUom, 5);
            var denominator = new NumericRepresentationValue(RepresentationInstanceList.vrDeltaTime.ToModelRepresentation(), denominatorValue);

            var quotient = numerator.Divide(denominator, RepresentationInstanceList.vrDeltaTime.ToModelRepresentation());
            Assert.AreEqual("ft1sec2", quotient.Value.UnitOfMeasure.Code);
            Assert.AreSame(RepresentationInstanceList.vrDeltaTime.ToModelRepresentation().Code, quotient.Representation.Code);
            Assert.AreEqual(2.508, quotient.Value.Value, Epsilon);
        }

        [Test]
        public void GivenVariableNumberWithCompositeUnitOfMeasureWhenDivdeVariableNumberWithCompositeUnitOfMeasureThenUnitOfMeasuresSimplified()
        {
            var numeratorUom = InternalUnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom();
            var numeratorValue = new NumericValue(numeratorUom, 52.15);
            var numerator = new NumericRepresentationValue(RepresentationInstanceList.vrEngineSpeed.ToModelRepresentation(), numeratorValue);
            var denominatorUom = InternalUnitSystemManager.Instance.UnitOfMeasures["gal1sec-1"].ToModelUom();
            var denominatorValue = new NumericValue(denominatorUom, 12);
            var denominator = new NumericRepresentationValue(RepresentationInstanceList.vrFuelRatePerHour.ToModelRepresentation(), denominatorValue);

            var quotient = numerator.Divide(denominator, RepresentationInstanceList.vrEngineSpeed.ToModelRepresentation());
            Assert.AreEqual("ft1gal-1", quotient.Value.UnitOfMeasure.Code);
            Assert.AreSame(RepresentationInstanceList.vrEngineSpeed.ToModelRepresentation().Code, quotient.Representation.Code);
            Assert.AreEqual(4.345833333333333, quotient.Value.Value, Epsilon);
        }

        [Test]
        public void GivenVariableNumberWhenMultiplyNumberThenUnitOfMeasuresCombined()
        {
            var uom = _ftUnitOfMeasure.ToModelUom();
            var leftValue = new NumericValue(uom, 12);
            var left = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), leftValue);
            var right = new NumericValue(uom, 4);

            var product = left.Multiply(right);
            Assert.IsInstanceOf<NumericRepresentationValue>(product);
            Assert.AreEqual("ft2", product.Value.UnitOfMeasure.Code);
            Assert.AreEqual(48, product.Value.Value);
        }

        [Test]
        public void GivenVariableNumberWhenMultiplyDoubleThenSourceValueIsProduct()
        {
            var uom = InternalUnitSystemManager.Instance.UnitOfMeasures["mi"].ToModelUom();
            var value = new NumericValue(uom, 3.62);
            var number = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), value);

            var result = number.Multiply(1.23);

            Assert.AreEqual(3.62 * 1.23, result.Value.Value, Epsilon);
        }

        [Test]
        public void GivenVariableNumberWithCompositeUnitOfMeasureWhenMultiplyVariableNumberThenCombinedUnitOfMeasure()
        {
            var leftUom = InternalUnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom();
            var leftValue = new NumericValue(leftUom, 47.5);
            var left = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), leftValue);
            var right = new NumericValue(_ftUnitOfMeasure.ToModelUom(), 3);

            var product = left.Multiply(right);
            Assert.IsInstanceOf<NumericRepresentationValue>(product);
            Assert.AreEqual("ft2sec-1", product.Value.UnitOfMeasure.Code);
            Assert.AreEqual(142.5, product.Value.Value);
        }

        [Test]
        public void GivenVariableNumberWhenMultiplyVariableNumberWithCompositeUnitOfMeasureThenCombinedUnitOfMeasure()
        {
            var leftUom = _ftUnitOfMeasure.ToModelUom();
            var leftValue = new NumericValue(leftUom, 52.78);
            var left = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), leftValue);

            var rightUom = InternalUnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom();
            var rightValue = new NumericValue(rightUom, 2.85);
            var right = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), rightValue);

            var product = left.Multiply(right, RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation());
            Assert.AreSame(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation().Code, product.Representation.Code);
            Assert.AreEqual("ft2sec-1", product.Value.UnitOfMeasure.Code);
            Assert.AreEqual(150.423, product.Value.Value);
        }

        [Test]
        public void GivenVariableNumberWithCompositeUnitOfMeasureWhenMultiplyVariableNumberWithCompositeUnitOfMeasureThenUnitsCancel()
        {
            var leftUom = InternalUnitSystemManager.Instance.UnitOfMeasures["ft1sec1"].ToModelUom();
            var leftValue = new NumericValue(leftUom, 5.15);
            var left = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), leftValue);
            var rightUom = InternalUnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom();
            var rightValue = new NumericValue(rightUom, 7.89);
            var right = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), rightValue);

            var product = left.Multiply(right, RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation());
            Assert.AreSame(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation().Code, product.Representation.Code);
            Assert.AreEqual("ft2", product.Value.UnitOfMeasure.Code);
            Assert.AreEqual(40.6335, product.Value.Value);
        }

        [Test]
        public void GivenVariableNumberWithCompositeUnitOfMeasureWhenMultiplyVariableNumberWithCompositeUnitOfMeasureThenCombinedUnitOfMeasure()
        {
            var uom = InternalUnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom();
            var leftValue = new NumericValue(uom, 21.848);
            var left = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), leftValue);
            var rightValue = new NumericValue(uom, 9.18);
            var right = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), rightValue);

            var product = left.Multiply(right, RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation());
            Assert.AreSame(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation().Code, product.Representation.Code);
            Assert.AreEqual("ft2[sec2]-1", product.Value.UnitOfMeasure.Code);
            Assert.AreEqual(200.56464, product.Value.Value);
        }

        [Test]
        public void GivenVariableNumbersWithTypesThatSimplifyToScalarTypeWhenMultiplyThenShouldHaveScalarUnit()
        {
            var leftUom = InternalUnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom();
            var leftValue = new NumericValue(leftUom, 21.848);
            var left = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), leftValue);
            var rightUom = InternalUnitSystemManager.Instance.UnitOfMeasures["sec"].ToModelUom();
            var rightValue = new NumericValue(rightUom, 9.18);
            var right = new NumericRepresentationValue(RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation(), rightValue);

            var product = left.Multiply(right, RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation());
            Assert.AreEqual("ft", product.Value.UnitOfMeasure.Code);
            //Assert.IsInstanceOf<ScalarUnitOfMeasure>(product.Value.UnitOfMeasure.Scale);??
        }

        [Test]
        public void GivenVariableNumberAndDoubleWhenAddToSourceShouldDoThat()
        {
            var uom = _ftUnitOfMeasure.ToModelUom();
            var value = new NumericValue(uom, 24.68);
            var number = new NumericRepresentationValue(RepresentationInstanceList.vrABShiftTrack.ToModelRepresentation(), value);
            number.AddToSource(10.11);

            Assert.AreEqual(34.79, number.Value.Value);
        }

        [Test]
        public void GivenVariableNumberAndDoubleWhenSubtractFromSourceShouldDoThat()
        {
            var uom = _ftUnitOfMeasure.ToModelUom();
            var value = new NumericValue(uom, 24.68);
            var number = new NumericRepresentationValue(RepresentationInstanceList.vrABShiftTrack.ToModelRepresentation(), value);
            number.SubtractFromSource(10.11);

            Assert.AreEqual(14.57, number.Value.Value);
        }

        [Test]
        public void GivenVariableNumberWhenSubtractVariableNumberFromSourceShouldDoThat()
        {
            var uom = _ftUnitOfMeasure.ToModelUom();
            var firstValue = new NumericValue(uom, 24.68);
            var secondValue = new NumericValue(uom, 10.11);
            var firstNumber = new NumericRepresentationValue(RepresentationInstanceList.vrABShiftTrack.ToModelRepresentation(), firstValue);
            var secondNumber = new NumericRepresentationValue(RepresentationInstanceList.vrABShiftTrack.ToModelRepresentation(), secondValue);

            firstNumber.SubtractFromSource(secondNumber);
            Assert.AreEqual(14.57, firstNumber.Value.Value);
        }

        [Test]
        public void GivenVariableNumberWhenAddVariableNumberToSourceShouldDoThat()
        {
            var uom = _ftUnitOfMeasure.ToModelUom();
            var firstValue = new NumericValue(uom, 24.68);
            var secondValue = new NumericValue(uom, 10.11);
            var firstNumber = new NumericRepresentationValue(RepresentationInstanceList.vrABShiftTrack.ToModelRepresentation(), firstValue);
            var secondNumber = new NumericRepresentationValue(RepresentationInstanceList.vrABShiftTrack.ToModelRepresentation(), secondValue);

            firstNumber.AddToSource(secondNumber);
            Assert.AreEqual(34.79, firstNumber.Value.Value);
        }

        [Test]
        public void GivenVariableNumberWhenToStringShouldPrettyPrint()
        {
            var uom = _ftUnitOfMeasure.ToModelUom();
            var value = new NumericValue(uom, 12.34);
            var number = new NumericRepresentationValue(RepresentationInstanceList.vrABShiftTrack.ToModelRepresentation(), uom, value);

            var result = number.ToString();

            Assert.AreEqual("12.34 ft (vrABShiftTrack)", result);
        }
    }
}
