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
  *    Abhinav Mir - added Kelvin and milliKelvin conversion tests
  *******************************************************************************/

using System;
using AgGateway.ADAPT.Representation.UnitSystem;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.UnitSystem
{
    [TestFixture]
    public class UnitOfMeasureConverterTest
    {
        private const double Epsilon = .001;
        private IUnitOfMeasureConverter _unitOfMeasureConverter;

        [SetUp]
        public void Setup()
        {
            _unitOfMeasureConverter = new UnitOfMeasureConverter();
        }

        [Test]
        public void GivenUnitsInTheSameSystemAndOfTheSameTypeWhenConvertThenValueIsConverted()
        {
            var sourceUom = InternalUnitSystemManager.Instance.UnitOfMeasures["ft"];
            var targetUom = InternalUnitSystemManager.Instance.UnitOfMeasures["in"];

            var value = _unitOfMeasureConverter.Convert(sourceUom, targetUom, 3);
            Assert.AreEqual(36, value, Epsilon);
        }

        [Test]
        public void GivenUnitsInDifferentSystemsAndOfTheSameTypeWhenConvertThenValueIsConverted()
        {
            var sourceUom = InternalUnitSystemManager.Instance.UnitOfMeasures["m"];
            var targetUom = InternalUnitSystemManager.Instance.UnitOfMeasures["in"];

            var value = _unitOfMeasureConverter.Convert(sourceUom, targetUom, 3);
            Assert.AreEqual(118.11, value, Epsilon);
        }

        [Test]
        public void GivenUnitsOfDifferentTypesWhenConvertThenException()
        {
            var sourceUom = InternalUnitSystemManager.Instance.UnitOfMeasures["ft"];
            var targetUom = InternalUnitSystemManager.Instance.UnitOfMeasures["gal"];

            Assert.Throws<InvalidOperationException>(() => _unitOfMeasureConverter.Convert(sourceUom, targetUom, 8));
        }

        [Test]
        public void GivenCompositeUnitsOfDifferentTypesWhenConvertThenException()
        {
            var sourceUom = new CompositeUnitOfMeasure("[cm3]1[m2]-1");
            var targetUom = new CompositeUnitOfMeasure("bale1[in2]-1");

            Assert.Throws<InvalidOperationException>(() => _unitOfMeasureConverter.Convert(sourceUom, targetUom, 3));
        }

        [Test]
        public void GivenCompoundUnitsInDifferentSystemWhenConvertThenValueIsConverted()
        {
            var sourceUom = new CompositeUnitOfMeasure("bale1[in2]-1");
            var targetUom = new CompositeUnitOfMeasure("bale1[ft2]-1");

            var result = _unitOfMeasureConverter.Convert(sourceUom, targetUom, 1);
            Assert.AreEqual(144, result, 0.000000001);

            sourceUom = new CompositeUnitOfMeasure("bale1[mm2]-1");
            result = _unitOfMeasureConverter.Convert(sourceUom, targetUom, 1);
            Assert.AreEqual(92903.04, result, 0.000000001);
        }

        [Test]
        public void GivenNestedCompoundUnitsInDifferentSystemsWhenConvertThenValueIsConverted()
        {
            var sourceUom = new CompositeUnitOfMeasure("[cm3]1[m2]-1");
            var targetUom = new CompositeUnitOfMeasure("[ft3]1[yd2]-1");

            var result = _unitOfMeasureConverter.Convert(sourceUom, targetUom, 100);

            Assert.AreEqual(0.00295275601, result, 0.000000001);
        }

        [Test]
        public void GivenScalarAndCompositeWhenConvertShouldUseCompositeConversionFactor()
        {
            var sourceUom = InternalUnitSystemManager.Instance.UnitOfMeasures["ac"];
            var targetUom = new CompositeUnitOfMeasure("m2");

            var result = _unitOfMeasureConverter.Convert(sourceUom, targetUom, 1);

            Assert.AreEqual(4046.8564223999997, result, Epsilon);
        }

        [Test]
        public void GivenCompositeUnitWhenConvertToScalarShouldUseCompositeConversionFactor()
        {
            var sourceUom = new CompositeUnitOfMeasure("m2");
            var targetUom = InternalUnitSystemManager.Instance.UnitOfMeasures["ac"];

            var result = _unitOfMeasureConverter.Convert(sourceUom, targetUom, 500000);

            Assert.AreEqual(123.553, result, Epsilon);
        }

        [Test]
        public void GivenCompositeUnitsOfMeasureWithZeroValuesWhenConvertThenZero()
        {
            var kilometersPerHour = new CompositeUnitOfMeasure("km1hr-1");
            var milesPerHour = new CompositeUnitOfMeasure("mi1hr-1");

            var result = _unitOfMeasureConverter.Convert(kilometersPerHour, milesPerHour, 0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void GivenCompositeUnitsOfMeasureWithSameNegativePowersWhenConvertThenConverted()
        {
            var kilometerPerHour = new CompositeUnitOfMeasure("km1hr-1");
            var milesPerHour = new CompositeUnitOfMeasure("mi1hr-1");

            var result = _unitOfMeasureConverter.Convert(kilometerPerHour, milesPerHour, 0.055);
            Assert.AreEqual(0.034175415573053369, result);
        }

        [Test]
        public void GivenFahrenheitAndKelvinWhenConvertThenValueIsConverted()
        {
            var sourceUom = InternalUnitSystemManager.Instance.UnitOfMeasures["F"];
            var targetUom = InternalUnitSystemManager.Instance.UnitOfMeasures["K"];

            Assert.AreEqual(310.15, _unitOfMeasureConverter.Convert(sourceUom, targetUom, 98.6), Epsilon);
            Assert.AreEqual(255.372, _unitOfMeasureConverter.Convert(sourceUom, targetUom, 0), Epsilon);
        }

        [Test]
        public void GivenFahrenheitAndMilliKelvinWhenConvertThenValueIsConverted()
        {
            var sourceUom = InternalUnitSystemManager.Instance.UnitOfMeasures["F"];
            var targetUom = InternalUnitSystemManager.Instance.UnitOfMeasures["mK"];

            Assert.AreEqual(310150, _unitOfMeasureConverter.Convert(sourceUom, targetUom, 98.6), Epsilon);
            Assert.AreEqual(255372.222, _unitOfMeasureConverter.Convert(sourceUom, targetUom, 0), Epsilon);
        }

        [Test]
        public void GivenKelvinAndMilliKelvinWhenConvertThenValueIsScaledByOneThousand()
        {
            var kelvin = InternalUnitSystemManager.Instance.UnitOfMeasures["K"];
            var milliKelvin = InternalUnitSystemManager.Instance.UnitOfMeasures["mK"];

            Assert.AreEqual(300000, _unitOfMeasureConverter.Convert(kelvin, milliKelvin, 300), Epsilon);
            Assert.AreEqual(300, _unitOfMeasureConverter.Convert(milliKelvin, kelvin, 300000), Epsilon);
        }

        [Test]
        public void GivenMilliKelvinAndCelsiusWhenConvertThenValueIsConverted()
        {
            var sourceUom = InternalUnitSystemManager.Instance.UnitOfMeasures["mK"];
            var targetUom = InternalUnitSystemManager.Instance.UnitOfMeasures["C"];

            Assert.AreEqual(15, _unitOfMeasureConverter.Convert(sourceUom, targetUom, 288150), Epsilon);
            Assert.AreEqual(0, _unitOfMeasureConverter.Convert(sourceUom, targetUom, 273150), Epsilon);
        }
    }
}
