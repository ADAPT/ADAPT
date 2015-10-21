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

using System.Globalization;
using AgGateway.ADAPT.Representation;
using AgGateway.ADAPT.Representation.Generated;
using AgGateway.ADAPT.Representation.UnitSystem;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.UnitSystem
{
    [TestFixture]
    public class UnitTypeTest
    {
        private UnitSystemUnitType _unitType;

        [SetUp]
        public void Setup()
        {
            _unitType = new UnitSystemUnitType();
        }

        [Test]
        public void GivenUnitTypeWhenGetNameThenNameForCultureIsFound()
        {
            _unitType.Name = new[]
            {
                new UnitSystemUnitTypeName
                {
                    locale = CultureInfoDefault.DefaultCulture,
                    Value = "Life"
                },
                new UnitSystemUnitTypeName
                {
                   locale = "de",
                   Value = "Leben"
                }
            };

            var culture = CultureInfo.GetCultureInfo("de");
            var unitType = new UnitType(_unitType, culture);
            Assert.AreEqual("Leben", unitType.Name);
        }

        [Test]
        public void GivenUnitTypeWhenGetDomainIdThenDomainId()
        {
            _unitType.domainID = "years";

            var unitType = new UnitType(_unitType);
            Assert.AreEqual("years", unitType.DomainID);
        }

        [Test]
        public void GivenUnitTypeWhenGetUnitsThenUnitsOfMeasureAreLoaded()
        {
            _unitType.Items = new object[]
            {
                new UnitSystemUnitTypeUnitTypeRepresentation
                {
                    domainID = "Anything",
                    UnitOfMeasure = new []
                    {
                        new UnitSystemUnitTypeUnitTypeRepresentationUnitOfMeasure
                        {
                            domainID = "Food"   
                        },
                        new UnitSystemUnitTypeUnitTypeRepresentationUnitOfMeasure
                        {
                            domainID = "Water"   
                        },
                        new UnitSystemUnitTypeUnitTypeRepresentationUnitOfMeasure
                        {
                            domainID = "Hydrogen"   
                        }
                    }
                }
            };

            var unitType = new UnitType(_unitType);
            Assert.AreEqual(3, unitType.Units.Count);
        }

        [Test]
        public void GivenUnitTypeWhenGetUnitsThenUnitOfMeasureCollection()
        {
            var unitType = new UnitType(_unitType);
            Assert.IsInstanceOf<UnitOfMeasureCollection>(unitType.Units);
        }
    }
}
