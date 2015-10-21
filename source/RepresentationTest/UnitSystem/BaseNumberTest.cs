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
using AgGateway.ADAPT.Representation.UnitSystem;
using Moq;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.UnitSystem
{
    [TestFixture]
    public class BaseNumberTest
    {
        private Mock<IUnitOfMeasureConverter> _unitOfMeasureConverterMock;
        private UnitOfMeasure _mileUnitOfMeasure = UnitSystemManager.Instance.UnitOfMeasures["mi"];
        private const double Epsilon = 0.0000000001;

        [SetUp]
        public void Setup()
        {
            _unitOfMeasureConverterMock = new Mock<IUnitOfMeasureConverter>();
        }
    
        [Test]
        public void GivenUnitOfMeasureWhenCreatedThenSourceUnitOfMeasureIsSet()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var baseNumber = new BaseNumber(sourceUom, 1.58);
            Assert.AreSame(sourceUom, baseNumber.UnitOfMeasure);
        }

        [Test]
        public void GivenUnitOfMeasureWhenCreatedThenTargetUnitOfMeasureDefaultsToSourceUnitOfMeasure()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var baseNumber = new BaseNumber(sourceUom, 1.58);
            Assert.AreSame(baseNumber.UnitOfMeasure, baseNumber.UnitOfMeasure);
        }

        [Test]
        public void GivenUnitOfMeasureWhenCreatedThenTargetValueDefaultsToSourceValue()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["m"];
            var baseNumber = new BaseNumber(sourceUom, 6.89);
            Assert.AreEqual(baseNumber.Value, baseNumber.Value);
        }

        [Test]
        public void GivenValueWhenCreatedThenSourceValueIsSet()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var baseNumber = new BaseNumber(sourceUom, 12.0);
            Assert.AreEqual(12.0, baseNumber.Value);
        }

        [Test]
        public void GivenBaseNumberWhenSetTargetThenTargetUnitOfMeasureIsSet()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var targetUom = UnitSystemManager.Instance.UnitOfMeasures["in"];
            var baseNumber = new BaseNumber(sourceUom, 12.0, _unitOfMeasureConverterMock.Object);

            baseNumber.ConvertToUnit(targetUom);
            Assert.AreSame(targetUom, baseNumber.UnitOfMeasure);
        }

        [Test]
        public void GivenBaseNumberWhenConvertUomThenValueIsSet()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var targetUom = UnitSystemManager.Instance.UnitOfMeasures["in"];
            _unitOfMeasureConverterMock.Setup(s => s.Convert(sourceUom, targetUom, 12.0)).Returns(50.0);
            var baseNumber = new BaseNumber(sourceUom, 12.0, _unitOfMeasureConverterMock.Object);

            baseNumber.ConvertToUnit(targetUom);
            Assert.AreEqual(50.0, baseNumber.Value);
        }

        [Test]
        public void GivenTwoBaseNumbersWithSameUomWhenAddedShouldReturnNewBaseNumberWithSumAsSourceValue()
        {
            var uom = UnitSystemManager.Instance.UnitOfMeasures["C"];
            var originalNumber = new BaseNumber(uom, 22);
            var secondNumber = new BaseNumber(uom, 11);

            var result = originalNumber.Add(secondNumber);
            Assert.AreEqual(33, result.Value);
        }

        [Test]
        public void GivenBaseNumberWhenAddBaseNumberThenResultIsInOriginalUom()
        {
            var originalUom = UnitSystemManager.Instance.UnitOfMeasures["m"];
            var originalNumber = new BaseNumber(originalUom, 1.75);

            var secondUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var secondNumber = new BaseNumber(secondUom, 3.5);

            var expected = 2.8168; //1.75m + (3.5ft -> m)
            var actual = originalNumber.Add(secondNumber);
            Assert.AreEqual(expected, actual.Value, Epsilon);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GivenBaseNumbersWithIncompatibleUnitsWhenAddThenException()
        {
            var originalUom = UnitSystemManager.Instance.UnitOfMeasures["m"];
            var originalNumber = new BaseNumber(originalUom, 1.75);

            var secondUom = UnitSystemManager.Instance.UnitOfMeasures["C"];
            var secondNumber = new BaseNumber(secondUom, 3.5);

            originalNumber.Add(secondNumber);
        }

        [Test]
        public void GivenTwoBaseNumbersWithSameUomWhenSubtractedReturnNewBaseNumberWithDifferenceAsSourceValue()
        {
            var uom = UnitSystemManager.Instance.UnitOfMeasures["C"];
            var originalNumber = new BaseNumber(uom, 22);
            var secondNumber = new BaseNumber(uom, 13);

            var result = originalNumber.Subtract(secondNumber);
            Assert.AreEqual(9, result.Value);
        }

        [Test]
        public void GivenBaseNumberWhenSubtractBaseNumberThenResultIsInOriginalUom()
        {
            var originalUom = UnitSystemManager.Instance.UnitOfMeasures["m"];
            var originalNumber = new BaseNumber(originalUom, 1.75);

            var secondUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var secondNumber = new BaseNumber(secondUom, 3.5);

            var expected = 0.6832; //1.75m + (3.5ft -> m)
            var actual = originalNumber.Subtract(secondNumber);
            Assert.AreEqual(expected, actual.Value, Epsilon);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GivenBaseNumbersWithIncompatibleUnitsWhenSubtractThenException()
        {
            var originalUom = UnitSystemManager.Instance.UnitOfMeasures["m"];
            var originalNumber = new BaseNumber(originalUom, 1.75);

            var secondUom = UnitSystemManager.Instance.UnitOfMeasures["C"];
            var secondNumber = new BaseNumber(secondUom, 3.5);

            originalNumber.Subtract(secondNumber);
        }

        [Test]
        public void GivenBaseNumberWhenAddDoubleShouldReturnNewBaseNumberWithSourceAddedToDouble()
        {
            var uom = _mileUnitOfMeasure;
            var number = new BaseNumber(uom, 3.62);

            var result = number.Add(1.23);

            Assert.AreEqual(4.85, result.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenSubtractDoubleShouldReturnNewBaseNumberWithDoubleSubtractedFromSource()
        {
            var uom = _mileUnitOfMeasure;
            var number = new BaseNumber(uom, 3.62);

            var result = number.Subtract(1.23);

            Assert.AreEqual(2.39, result.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenMultiplyDoubleShouldReturnNewBaseNumberWithSourceMultipliedByDouble()
        {
            var uom = _mileUnitOfMeasure;
            var number = new BaseNumber(uom, 3.62);

            var result = number.Multiply(1.23);

            Assert.AreEqual(3.62 * 1.23, result.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenDivideDoubleShouldReturnNewBaseNumberWithSourceDividedByDouble()
        {
            var uom = _mileUnitOfMeasure;
            var number = new BaseNumber(uom, 3.62);

            var result = number.Divide(1.23);

            Assert.AreEqual(3.62 / 1.23, result.Value, Epsilon);
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void GivenBaseNumberWhenDivideByZeroShouldThrowException()
        {
            var uom = _mileUnitOfMeasure;
            var number = new BaseNumber(uom, 3.62);

            number.Divide(0);
        }

        [Test]
        public void GivenBaseNumberWhenDivideBaseNumberThenUnitOfMeasuresCombined()
        {
            var numerator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft"], 12);
            var denominator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["sec"], 5);

            var quotient = numerator.Divide(denominator);
            Assert.AreEqual("ft1sec-1", quotient.UnitOfMeasure.DomainID);
            Assert.AreEqual(2.4, quotient.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenDivideBaseNumberWithSameUnitThenValueDivided()
        {
            var numerator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft"], 12);
            var denominator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft"], 6);

            var quotient = numerator.Divide(denominator);
            Assert.AreEqual("ratio", quotient.UnitOfMeasure.DomainID);
            Assert.AreEqual(2, quotient.Value, Epsilon);
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void GivenBaseNumberWhenDivideBaseNumberWithZeroValueThenDivideByZeroException()
        {
            var numerator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft"], 3);
            var denominator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["sec"], 0);

            numerator.Divide(denominator);
        }

        [Test]
        public void GivenVariableNunmberWithCompositeUnitOfMeasureWhenDivideBaseNumberThenUnitOfMeasuresCombined()
        {
            var numerator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"], 2.4);
            var denominator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["sec"], 5);

            var quotient = numerator.Divide(denominator);
            Assert.AreEqual("ft1[sec2]-1", quotient.UnitOfMeasure.DomainID);
            Assert.AreEqual(.48, quotient.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenWhenDivideBaseNumberWithCompositeUnitOfMeasureThenUnitOfMeasuresSimplified()
        {
            var numerator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft"], 12.54);
            var denominator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["[sec2]-1"], 5);

            var quotient = numerator.Divide(denominator);
            Assert.AreEqual("ft1sec2", quotient.UnitOfMeasure.DomainID);
            Assert.AreEqual(2.508, quotient.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUnitOfMeasureWhenDivdeBaseNumberWithCompositeUnitOfMeasureThenUnitOfMeasuresSimplified()
        {
            var numerator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"], 52.15);
            var denominator = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["gal1sec-1"], 12);

            var quotient = numerator.Divide(denominator);
            Assert.AreEqual("ft1gal-1", quotient.UnitOfMeasure.DomainID);
            Assert.AreEqual(4.345833333333333, quotient.Value, Epsilon);

        }

        [Test]
        public void GivenBaseNumberWhenMultiplyBaseNumberThenUnitOfMeasuresCombined()
        {
            var left = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft"], 12);
            var right = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft"], 4);

            var product = left.Multiply(right);
            Assert.AreEqual("ft2", product.UnitOfMeasure.DomainID);
            Assert.AreEqual(48, product.Value);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUnitOfMeasureWhenMultiplyBaseNumberThenCombinedUnitOfMeasure()
        {
            var left = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"], 47.5);
            var right = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft"], 3);

            var product = left.Multiply(right);
            Assert.AreEqual("ft2sec-1", product.UnitOfMeasure.DomainID);
            Assert.AreEqual(142.5, product.Value);
        }

        [Test]
        public void GivenBaseNumberWhenMultiplyBaseNumberWithCompositeUnitOfMeasureThenCombinedUnitOfMeasure()
        {
            var left = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft"], 52.78);
            var right = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"], 2.85);

            var product = left.Multiply(right);
            Assert.AreEqual("ft2sec-1", product.UnitOfMeasure.DomainID);
            Assert.AreEqual(150.423, product.Value);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUnitOfMeasureWhenMultiplyBaseNumberWithCompositeUnitOfMeasureThenUnitsCancel()
        {
            var left = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft1sec1"], 5.15);
            var right = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"], 7.89);

            var product = left.Multiply(right);
            Assert.AreEqual("ft2", product.UnitOfMeasure.DomainID);
            Assert.AreEqual(40.6335, product.Value);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUomThatWillCancelWhenMultiplyThenCombinedUnitOfMeasure()
        {
            var left = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["kg1ac-1"], 352.14);
            var right = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["m2"], 13.6);

            var product = left.Multiply(right);
            Assert.AreEqual("kg", product.UnitOfMeasure.DomainID);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUomThatWillCombineWhenMultiplyThenCombinedUnitOfMeasure()
        {
            var left = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ac"], 352.14);
            var right = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["m2"], 13.6);

            var product = left.Multiply(right);
            Assert.AreEqual("m4", product.UnitOfMeasure.DomainID);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUomThatWillCancelWhenMultipliedThenCombinedUnitOfMeasure()
        {
            var left = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["mg1ac1"], 352.14);
            var right = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["[m2]-1"], 13.6);

            var product = left.Multiply(right);
            Assert.AreEqual("mg", product.UnitOfMeasure.DomainID);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUnitOfMeasureWhenMultiplyBaseNumberWithCompositeUnitOfMeasureThenCombinedUnitOfMeasure()
        {
            var left = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"], 21.848);
            var right = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"], 9.18);

            var product = left.Multiply(right);
            Assert.AreEqual("ft2[sec2]-1", product.UnitOfMeasure.DomainID);
            Assert.AreEqual(200.56464, product.Value);
        }

        [Test]
        public void GivenBaseNumberAndDoubleValueWhenAddToSourceShouldAddDoubleToSourceValue()
        {
            var number = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["mg"], 3.14);
            number.AddToSource(4.13);

            Assert.AreEqual(7.27, number.Value, Epsilon);
        }

        [Test]
        public void GivenTwoScalarValuesWhenConvertedThenResultIsConvertedCorrectly()
        {
            var number = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["seeds1ac-1"], 30213.0);
            number.ConvertToUnit(UnitSystemManager.Instance.UnitOfMeasures["seeds1ha-1"]);

            Assert.AreEqual(74657.948902674674, number.Value, Epsilon);
        }


        [Test]
        public void GivenNullWhenAddToSourceShouldReturnSourceValue()
        {
            var number = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["lb"], 22.1);
            number.AddToSource(null);

            Assert.AreEqual(22.1, number.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenAddBaseNumberToSourceThenShouldAddTheSecondNumberToSourceValue()
        {
            var firstNumber = new BaseNumber(_mileUnitOfMeasure, 42.24);
            var secondNumber = new BaseNumber(_mileUnitOfMeasure, 12.34);

            firstNumber.AddToSource(secondNumber);

            Assert.AreEqual(54.58, firstNumber.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenAddBaseNumberWithDifferentUnitOfMeasureThenShouldConvertAndAddToSource()
        {
            var firstNumber = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["cm"], 1);
            var secondNumber = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["in"], 1);

            firstNumber.AddToSource(secondNumber);

            Assert.AreEqual(3.54, firstNumber.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberAndDoubleWhenSubtractFromSourceShouldSubtractFromSource()
        {
            var firstNumber = new BaseNumber(_mileUnitOfMeasure, 42.24);
            firstNumber.SubtractFromSource(12.13);

            Assert.AreEqual(30.11, firstNumber.Value, Epsilon);
        }

        [Test]
        public void GivenNullWhenSubtractFromSourceShoulReturnSourceValue()
        {
            var number = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["cm"], 4.25);
            number.SubtractFromSource(null);

            Assert.AreEqual(4.25, number.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenSubtractBaseNumberFromSourceShouldSubtractValueFromSourceValue()
        {
            var number = new BaseNumber(_mileUnitOfMeasure, 9.876);
            var secondNumber = new BaseNumber(_mileUnitOfMeasure, 1.234);

            number.SubtractFromSource(secondNumber);

            Assert.AreEqual(8.642, number.Value);
        }

        [Test]
        public void GivenBaseNumberWhenSubtractBaseNumberWithDifferentUnitOfMeasureThenShouldConvertAndSubtractFromSource()
        {
            var firstNumber = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["cm"], 3.54);
            var secondNumber = new BaseNumber(UnitSystemManager.Instance.UnitOfMeasures["in"], 1);

            firstNumber.SubtractFromSource(secondNumber);

            Assert.AreEqual(1, firstNumber.Value, Epsilon);
        }

    }
}
