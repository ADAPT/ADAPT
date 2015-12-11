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
  *    Joseph Ross - Renamed File
  *******************************************************************************/

using System;
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.Representation.UnitSystem;
using AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods;
using NUnit.Framework;
using UnitOfMeasure = AgGateway.ADAPT.Representation.UnitSystem.UnitOfMeasure;

namespace AgGateway.ADAPT.RepresentationTest.UnitSystem
{
    [TestFixture]
    public class NumericValueExtensionsTest
    {
        private readonly UnitOfMeasure _mileUnitOfMeasure = UnitSystemManager.Instance.UnitOfMeasures["mi"];
        private const double Epsilon = 0.0000000001;

        [Test]
        public void GivenUnitOfMeasureWhenCreatedThenSourceUnitOfMeasureIsSet()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var baseNumber = new NumericValue(sourceUom.ToModelUom(), 1.58);
            Assert.AreEqual(sourceUom.DomainID, baseNumber.UnitOfMeasure.Code);
        }

        [Test]
        public void GivenUnitOfMeasureWhenCreatedThenTargetUnitOfMeasureDefaultsToSourceUnitOfMeasure()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var baseNumber = new NumericValue(sourceUom.ToModelUom(), 1.58);
            Assert.AreSame(baseNumber.UnitOfMeasure, baseNumber.UnitOfMeasure);
        }

        [Test]
        public void GivenUnitOfMeasureWhenCreatedThenTargetValueDefaultsToSourceValue()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["m"];
            var baseNumber = new NumericValue(sourceUom.ToModelUom(), 6.89);
            Assert.AreEqual(baseNumber.Value, baseNumber.Value);
        }

        [Test]
        public void GivenValueWhenCreatedThenSourceValueIsSet()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var baseNumber = new NumericValue(sourceUom.ToModelUom(), 12.0);
            Assert.AreEqual(12.0, baseNumber.Value);
        }

        [Test]
        public void GivenBaseNumberWhenSetTargetThenTargetUnitOfMeasureIsSet()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var targetUom = UnitSystemManager.Instance.UnitOfMeasures["in"];
            var baseNumber = new NumericValue(sourceUom.ToModelUom(), (double)12.0);

            baseNumber.ConvertToUnit(targetUom);
            Assert.AreEqual(targetUom.DomainID, baseNumber.UnitOfMeasure.Code);
        }

        [Test]
        public void GivenBaseNumberWhenConvertUomThenValueIsSet()
        {
            var sourceUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var targetUom = UnitSystemManager.Instance.UnitOfMeasures["in"];
            var baseNumber = new NumericValue(sourceUom.ToModelUom(), 12.0);

            baseNumber.ConvertToUnit(targetUom);
            Assert.AreEqual(144.0, baseNumber.Value, Epsilon);
        }

        [Test]
        public void GivenTwoBaseNumbersWithSameUomWhenAddedShouldReturnNewBaseNumberWithSumAsSourceValue()
        {
            var uom = UnitSystemManager.Instance.UnitOfMeasures["C"];
            var originalNumber = new NumericValue(uom.ToModelUom(), 22);
            var secondNumber = new NumericValue(uom.ToModelUom(), 11);

            var result = originalNumber.Add(secondNumber);
            Assert.AreEqual(33, result.Value);
        }

        [Test]
        public void GivenBaseNumberWhenAddBaseNumberThenResultIsInOriginalUom()
        {
            var originalUom = UnitSystemManager.Instance.UnitOfMeasures["m"];
            var originalNumber = new NumericValue(originalUom.ToModelUom(), 1.75);

            var secondUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var secondNumber = new NumericValue(secondUom.ToModelUom(), 3.5);

            var expected = 2.8168; //1.75m + (3.5ft -> m)
            var actual = originalNumber.Add(secondNumber);
            Assert.AreEqual(expected, actual.Value, Epsilon);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GivenBaseNumbersWithIncompatibleUnitsWhenAddThenException()
        {
            var originalUom = UnitSystemManager.Instance.UnitOfMeasures["m"];
            var originalNumber = new NumericValue(originalUom.ToModelUom(), 1.75);

            var secondUom = UnitSystemManager.Instance.UnitOfMeasures["C"];
            var secondNumber = new NumericValue(secondUom.ToModelUom(), 3.5);

            originalNumber.Add(secondNumber);
        }

        [Test]
        public void GivenTwoBaseNumbersWithSameUomWhenSubtractedReturnNewBaseNumberWithDifferenceAsSourceValue()
        {
            var uom = UnitSystemManager.Instance.UnitOfMeasures["C"];
            var originalNumber = new NumericValue(uom.ToModelUom(), 22);
            var secondNumber = new NumericValue(uom.ToModelUom(), 13);

            var result = originalNumber.Subtract(secondNumber);
            Assert.AreEqual(9, result.Value);
        }

        [Test]
        public void GivenBaseNumberWhenSubtractBaseNumberThenResultIsInOriginalUom()
        {
            var originalUom = UnitSystemManager.Instance.UnitOfMeasures["m"];
            var originalNumber = new NumericValue(originalUom.ToModelUom(), 1.75);

            var secondUom = UnitSystemManager.Instance.UnitOfMeasures["ft"];
            var secondNumber = new NumericValue(secondUom.ToModelUom(), 3.5);

            var expected = 0.6832; //1.75m - (3.5ft -> m)
            var actual = originalNumber.Subtract(secondNumber);
            Assert.AreEqual(expected, actual.Value, Epsilon);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GivenBaseNumbersWithIncompatibleUnitsWhenSubtractThenException()
        {
            var originalUom = UnitSystemManager.Instance.UnitOfMeasures["m"];
            var originalNumber = new NumericValue(originalUom.ToModelUom(), 1.75);

            var secondUom = UnitSystemManager.Instance.UnitOfMeasures["C"];
            var secondNumber = new NumericValue(secondUom.ToModelUom(), 3.5);

            originalNumber.Subtract(secondNumber);
        }

        [Test]
        public void GivenBaseNumberWhenAddDoubleShouldReturnNewBaseNumberWithSourceAddedToDouble()
        {
            var uom = _mileUnitOfMeasure;
            var number = new NumericValue(uom.ToModelUom(), 3.62);

            var result = number.Add(1.23);

            Assert.AreEqual(4.85, result.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenSubtractDoubleShouldReturnNewBaseNumberWithDoubleSubtractedFromSource()
        {
            var uom = _mileUnitOfMeasure;
            var number = new NumericValue(uom.ToModelUom(), 3.62);

            var result = number.Subtract(1.23);

            Assert.AreEqual(2.39, result.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenMultiplyDoubleShouldReturnNewBaseNumberWithSourceMultipliedByDouble()
        {
            var uom = _mileUnitOfMeasure;
            var number = new NumericValue(uom.ToModelUom(), 3.62);

            var result = number.Multiply(1.23);

            Assert.AreEqual(3.62 * 1.23, result.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenDivideDoubleShouldReturnNewBaseNumberWithSourceDividedByDouble()
        {
            var uom = _mileUnitOfMeasure;
            var number = new NumericValue(uom.ToModelUom(), 3.62);

            var result = number.Divide(1.23);

            Assert.AreEqual(3.62 / 1.23, result.Value, Epsilon);
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void GivenBaseNumberWhenDivideByZeroShouldThrowException()
        {
            var uom = _mileUnitOfMeasure;
            var number = new NumericValue(uom.ToModelUom(), 3.62);

            number.Divide(0);
        }

        [Test]
        public void GivenBaseNumberWhenDivideBaseNumberThenUnitOfMeasuresCombined()
        {
            var numerator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft"].ToModelUom(), 12);
            var denominator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["sec"].ToModelUom(), 5);

            var quotient = numerator.Divide(denominator);
            Assert.AreEqual("ft1sec-1", quotient.UnitOfMeasure.Code);
            Assert.AreEqual(2.4, quotient.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenDivideBaseNumberWithSameUnitThenValueDivided()
        {
            var numerator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft"].ToModelUom(), 12);
            var denominator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft"].ToModelUom(), 6);

            var quotient = numerator.Divide(denominator);
            Assert.AreEqual("ratio", quotient.UnitOfMeasure.Code);
            Assert.AreEqual(2, quotient.Value, Epsilon);
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void GivenBaseNumberWhenDivideBaseNumberWithZeroValueThenDivideByZeroException()
        {
            var numerator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft"].ToModelUom(), 3);
            var denominator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["sec"].ToModelUom(), 0);

            numerator.Divide(denominator);
        }

        [Test]
        public void GivenNumericValueWithCompositeUnitOfMeasureWhenDivideBaseNumberThenUnitOfMeasuresCombined()
        {
            var numerator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom(), 2.4);
            var denominator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["sec"].ToModelUom(), 5);

            var quotient = numerator.Divide(denominator);
            Assert.AreEqual("ft1[sec2]-1", quotient.UnitOfMeasure.Code);
            Assert.AreEqual(.48, quotient.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenWhenDivideBaseNumberWithCompositeUnitOfMeasureThenUnitOfMeasuresSimplified()
        {
            var numerator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft"].ToModelUom(), 12.54);
            var denominator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["[sec2]-1"].ToModelUom(), 5);

            var quotient = numerator.Divide(denominator);
            Assert.AreEqual("ft1sec2", quotient.UnitOfMeasure.Code);
            Assert.AreEqual(2.508, quotient.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUnitOfMeasureWhenDivdeBaseNumberWithCompositeUnitOfMeasureThenUnitOfMeasuresSimplified()
        {
            var numerator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom(), 52.15);
            var denominator = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["gal1sec-1"].ToModelUom(), 12);

            var quotient = numerator.Divide(denominator);
            Assert.AreEqual("ft1gal-1", quotient.UnitOfMeasure.Code);
            Assert.AreEqual(4.345833333333333, quotient.Value, Epsilon);

        }

        [Test]
        public void GivenBaseNumberWhenMultiplyBaseNumberThenUnitOfMeasuresCombined()
        {
            var left = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft"].ToModelUom(), 12);
            var right = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft"].ToModelUom(), 4);

            var product = left.Multiply(right);
            Assert.AreEqual("ft2", product.UnitOfMeasure.Code);
            Assert.AreEqual(48, product.Value);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUnitOfMeasureWhenMultiplyBaseNumberThenCombinedUnitOfMeasure()
        {
            var left = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom(), 47.5);
            var right = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft"].ToModelUom(), 3);

            var product = left.Multiply(right);
            Assert.AreEqual("ft2sec-1", product.UnitOfMeasure.Code);
            Assert.AreEqual(142.5, product.Value);
        }

        [Test]
        public void GivenBaseNumberWhenMultiplyBaseNumberWithCompositeUnitOfMeasureThenCombinedUnitOfMeasure()
        {
            var left = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft"].ToModelUom(), 52.78);
            var right = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom(), 2.85);

            var product = left.Multiply(right);
            Assert.AreEqual("ft2sec-1", product.UnitOfMeasure.Code);
            Assert.AreEqual(150.423, product.Value);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUnitOfMeasureWhenMultiplyBaseNumberWithCompositeUnitOfMeasureThenUnitsCancel()
        {
            var left = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft1sec1"].ToModelUom(), 5.15);
            var right = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom(), 7.89);

            var product = left.Multiply(right);
            Assert.AreEqual("ft2", product.UnitOfMeasure.Code);
            Assert.AreEqual(40.6335, product.Value);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUomThatWillCancelWhenMultiplyThenCombinedUnitOfMeasure()
        {
            var left = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["kg1ac-1"].ToModelUom(), 352.14);
            var right = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["m2"].ToModelUom(), 13.6);

            var product = left.Multiply(right);
            Assert.AreEqual("kg", product.UnitOfMeasure.Code);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUomThatWillCombineWhenMultiplyThenCombinedUnitOfMeasure()
        {
            var left = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ac"].ToModelUom(), 352.14);
            var right = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["m2"].ToModelUom(), 13.6);

            var product = left.Multiply(right);
            Assert.AreEqual("m4", product.UnitOfMeasure.Code);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUomThatWillCancelWhenMultipliedThenCombinedUnitOfMeasure()
        {
            var left = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["mg1ac1"].ToModelUom(), 352.14);
            var right = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["[m2]-1"].ToModelUom(), 13.6);

            var product = left.Multiply(right);
            Assert.AreEqual("mg", product.UnitOfMeasure.Code);
        }

        [Test]
        public void GivenBaseNumberWithCompositeUnitOfMeasureWhenMultiplyBaseNumberWithCompositeUnitOfMeasureThenCombinedUnitOfMeasure()
        {
            var left = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom(), 21.848);
            var right = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["ft1sec-1"].ToModelUom(), 9.18);

            var product = left.Multiply(right);
            Assert.AreEqual("ft2[sec2]-1", product.UnitOfMeasure.Code);
            Assert.AreEqual(200.56464, product.Value);
        }

        [Test]
        public void GivenBaseNumberAndDoubleValueWhenAddToSourceShouldAddDoubleToSourceValue()
        {
            var number = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["mg"].ToModelUom(), 3.14);
            number.AddToSource(4.13);

            Assert.AreEqual(7.27, number.Value, Epsilon);
        }

        [Test]
        public void GivenTwoScalarValuesWhenConvertedThenResultIsConvertedCorrectly()
        {
            var number = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["seeds1ac-1"].ToModelUom(), 30213.0);
            number.ConvertToUnit(UnitSystemManager.Instance.UnitOfMeasures["seeds1ha-1"]);

            Assert.AreEqual(74657.948902674674, number.Value, Epsilon);
        }


        [Test]
        public void GivenNullWhenAddToSourceShouldReturnSourceValue()
        {
            var number = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["lb"].ToModelUom(), 22.1);
            number.AddToSource(null);

            Assert.AreEqual(22.1, number.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenAddBaseNumberToSourceThenShouldAddTheSecondNumberToSourceValue()
        {
            var firstNumber = new NumericValue(_mileUnitOfMeasure.ToModelUom(), 42.24);
            var secondNumber = new NumericValue(_mileUnitOfMeasure.ToModelUom(), 12.34);

            firstNumber.AddToSource(secondNumber);

            Assert.AreEqual(54.58, firstNumber.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenAddBaseNumberWithDifferentUnitOfMeasureThenShouldConvertAndAddToSource()
        {
            var firstNumber = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["cm"].ToModelUom(), 1);
            var secondNumber = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["in"].ToModelUom(), 1);

            firstNumber.AddToSource(secondNumber);

            Assert.AreEqual(3.54, firstNumber.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberAndDoubleWhenSubtractFromSourceShouldSubtractFromSource()
        {
            var firstNumber = new NumericValue(_mileUnitOfMeasure.ToModelUom(), 42.24);
            firstNumber.SubtractFromSource(12.13);

            Assert.AreEqual(30.11, firstNumber.Value, Epsilon);
        }

        [Test]
        public void GivenNullWhenSubtractFromSourceShoulReturnSourceValue()
        {
            var number = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["cm"].ToModelUom(), 4.25);
            number.SubtractFromSource(null);

            Assert.AreEqual(4.25, number.Value, Epsilon);
        }

        [Test]
        public void GivenBaseNumberWhenSubtractBaseNumberFromSourceShouldSubtractValueFromSourceValue()
        {
            var number = new NumericValue(_mileUnitOfMeasure.ToModelUom(), 9.876);
            var secondNumber = new NumericValue(_mileUnitOfMeasure.ToModelUom(), 1.234);

            number.SubtractFromSource(secondNumber);

            Assert.AreEqual(8.642, number.Value);
        }

        [Test]
        public void GivenBaseNumberWhenSubtractBaseNumberWithDifferentUnitOfMeasureThenShouldConvertAndSubtractFromSource()
        {
            var firstNumber = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["cm"].ToModelUom(), 3.54);
            var secondNumber = new NumericValue(UnitSystemManager.Instance.UnitOfMeasures["in"].ToModelUom(), 1);

            firstNumber.SubtractFromSource(secondNumber);

            Assert.AreEqual(1, firstNumber.Value, Epsilon);
        }

    }
}
