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
    public class UnitDimensionTest
    {
        private UnitSystemUnitDimension _unitDimension;

        [SetUp]
        public void Setup()
        {
            _unitDimension = new UnitSystemUnitDimension();
        }

        [Test]
        public void GivenUnitDimensionWhenGetNameThenNameForCultureIsFound()
        {
            _unitDimension.Name = new[]
            {
                new UnitSystemUnitDimensionName
                {
                    locale = CultureInfoDefault.DefaultCulture,
                    Value = "Life"
                },
                new UnitSystemUnitDimensionName
                {
                   locale = "de",
                   Value = "Leben"
                }
            };

            var culture = CultureInfo.GetCultureInfo("de");
            var unitDimension = new UnitDimension(_unitDimension, culture);
            Assert.AreEqual("Leben", unitDimension.Name);
        }

        [Test]
        public void GivenUnitDimensionWhenGetDomainIdThenDomainId()
        {
            _unitDimension.domainID = "years";

            var unitDimension = new UnitDimension(_unitDimension);
            Assert.AreEqual("years", unitDimension.DomainID);
        }

        [Test]
        public void GivenUnitDimensionWhenGetUnitsThenUnitsOfMeasureAreLoaded()
        {
            _unitDimension.Items = new object[]
            {
                new UnitSystemUnitDimensionUnitDimensionRepresentation
                {
                    domainID = "Anything",
                    UnitOfMeasure = new []
                    {
                        new UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasure
                        {
                            domainID = "Food"   
                        },
                        new UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasure
                        {
                            domainID = "Water"   
                        },
                        new UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasure
                        {
                            domainID = "Hydrogen"   
                        }
                    }
                }
            };

            var UnitDimension = new UnitDimension(_unitDimension);
            Assert.AreEqual(3, UnitDimension.Units.Count);
        }

        [Test]
        public void GivenUnitDimensionWhenGetUnitsThenUnitOfMeasureCollection()
        {
            var UnitDimension = new UnitDimension(_unitDimension);
            Assert.IsInstanceOf<UnitOfMeasureCollection>(UnitDimension.Units);
        }
    }
}
