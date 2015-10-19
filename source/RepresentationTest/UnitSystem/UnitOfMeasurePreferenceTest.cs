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

using AgGateway.ADAPT.Representation.Generated;
using AgGateway.ADAPT.Representation.UnitSystem;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.UnitSystem
{
    [TestFixture]
    public class UnitOfMeasurePreferenceTest
    {
        [Test]
        public void CreateUomPreferenceGivenPreferenceTypeShouldMapUnit()
        {
            var preferenceType = new UnitOfMeasurePreferenceType {unitOfMeasure = "m"};
            var uomPreference = new UnitOfMeasurePreference(preferenceType);

            Assert.AreEqual(UnitSystemManager.Instance.UnitOfMeasures["m"], uomPreference.UnitOfMeasure);
        }

        [Test]
        public void CreateUomPreferenceGivenPreferenceTypeShouldMapMinAndMaxValue()
        {
            var preferenceType = new UnitOfMeasurePreferenceType
            {
                unitOfMeasure = "m",
                minValue = 13.2,
                maxValue = 1445.67
            };
            var uomPreference = new UnitOfMeasurePreference(preferenceType);
            Assert.AreEqual(13.2, uomPreference.MinValue);
            Assert.AreEqual(1445.67, uomPreference.MaxValue);
        }

        [Test]
        public void CreateUomPreferenceGivenPreferenceTypeShouldMapDecimals()
        {
            var preferenceType = new UnitOfMeasurePreferenceType {unitOfMeasure = "m", @decimal = 3};
            var uomPreference = new UnitOfMeasurePreference(preferenceType);

            Assert.AreEqual(3, uomPreference.DecimalPlaces);
        }

        [Test]
        public void CreateUomPreferenceGivenPreferenceTypeShouldMapUnitSystemType()
        {
            var preferenceType = new UnitOfMeasurePreferenceType
            {
                unitOfMeasureSystem = "umsEnglish"
            };
            var uomPreference = new UnitOfMeasurePreference(preferenceType);

            Assert.AreEqual(Representation.UnitSystem.UnitSystem.umsEnglish, uomPreference.UnitSystem);
        }
    }
}
