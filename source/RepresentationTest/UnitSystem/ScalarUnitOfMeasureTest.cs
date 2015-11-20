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
    public class ScalarUnitOfMeasureTest
    {
        private UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasure _unitOfMeasure;
        private UnitDimension _unitDimension;

        [SetUp]
        public void Setup()
        {
            _unitDimension = new UnitDimension(new UnitSystemUnitDimension());
            _unitOfMeasure = new UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasure();
        }

        [Test]
        public void GivenUnitOfMeasureWhenGetDomainIdThenDomainId()
        {
            _unitOfMeasure.domainID = "Branch";

            var unitOfMeasure = new ScalarUnitOfMeasure(_unitOfMeasure, _unitDimension);
            Assert.AreEqual("Branch", unitOfMeasure.DomainID);
        }

        [Test]
        public void GivenUnitOfMeasureWhenGetLabelThenLabelForCultureIsFound()
        {
            _unitOfMeasure.Name = new[]
            {
                new UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasureName
                {
                    locale = "de",
                    label = "Herkunft"
                },
                new UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasureName
                {
                    locale = CultureInfoDefault.DefaultCulture,
                    label = "Origin"
                }
            };

            var culture = CultureInfo.GetCultureInfo("de");
            var unitOfMeasure = new ScalarUnitOfMeasure(_unitOfMeasure, _unitDimension, culture);
            Assert.AreEqual("Herkunft", unitOfMeasure.Label);
        }

        [Test]
        public void GivenUnitOfMeasureWhenGetPluralThenPluralForCultureIsFound()
        {
            _unitOfMeasure.Name = new[]
            {
                new UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasureName
                {
                    locale = "de",
                    plural = "Ursprünge"
                },
                new UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasureName
                {
                    locale = CultureInfoDefault.DefaultCulture,
                    plural = "Origins"
                }
            };

            var culture = CultureInfo.GetCultureInfo("de");
            var unitOfMeasure = new ScalarUnitOfMeasure(_unitOfMeasure, _unitDimension, culture);
            Assert.AreEqual("Ursprünge", unitOfMeasure.LabelPlural);
        }

        [Test]
        public void GivenUnitOfMeasureWhenGetUomIdThenUomId()
        {
            _unitOfMeasure.uomID = 5;

            var unitOfMeasure = new ScalarUnitOfMeasure(_unitOfMeasure, _unitDimension);
            Assert.AreEqual(5, unitOfMeasure.UomId);
        }

        [Test]
        public void GivenUnitOfMeasureWhenGetBaseOffsetThenBaseOffset()
        {
            _unitOfMeasure.baseOffset = 5.516;

            var unitOfMeasure = new ScalarUnitOfMeasure(_unitOfMeasure, _unitDimension);
            Assert.AreEqual(5.516, unitOfMeasure.BaseOffset);
        }

        [Test]
        public void GivenUnitOfMeasureWhenGetScaleThenScale()
        {
            _unitOfMeasure.scale = 783681;

            var unitOfMeasure = new ScalarUnitOfMeasure(_unitOfMeasure, _unitDimension);
            Assert.AreEqual(783681, unitOfMeasure.Scale);
        }

        [Test]
        public void GivenUnitDimensionWhenGetUnitDimensionThenUnitDimension()
        {
            var unitOfMeasure = new ScalarUnitOfMeasure(_unitOfMeasure, _unitDimension);
            Assert.AreSame(_unitDimension, unitOfMeasure.UnitDimension);
        }
    }
}
