/*******************************************************************************
  * Copyright (c) 2015 AgGateway and ADAPT Contributors
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html
  *
  * Contributors:
  *    Abhinav Mir - tests for the Dimension property on the model representation
  *******************************************************************************/

using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using AgGateway.ADAPT.Representation.RepresentationSystem.ExtensionMethods;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.RepresentationSystem
{
    [TestFixture]
    public class RepresentationExtensionsTest
    {
        [Test]
        public void GivenDistanceRepresentationWhenToModelRepresentationThenDimensionIsDistance()
        {
            var representation = RepresentationInstanceList.vrDistanceTraveled.ToModelRepresentation();

            Assert.AreEqual(UnitOfMeasureDimensionEnum.Distance, representation.Dimension);
        }

        [Test]
        public void GivenMassPerVolumeRepresentationWhenToModelRepresentationThenDimensionIsMassPerVolume()
        {
            var representation = RepresentationInstanceList.vrIngredientDensity.ToModelRepresentation();

            Assert.AreEqual(UnitOfMeasureDimensionEnum.MassPerVolume, representation.Dimension);
        }

        [Test]
        public void GivenTemperatureRepresentationWhenToModelRepresentationThenDimensionIsTemperature()
        {
            var representation = RepresentationInstanceList.vrAirTemperature.ToModelRepresentation();

            Assert.AreEqual(UnitOfMeasureDimensionEnum.Temperature, representation.Dimension);
        }

        [Test]
        public void GivenPerVolumeRepresentationWhenToModelRepresentationThenDimensionIsPerVolume()
        {
            var representation = RepresentationInstanceList.vrPricePerBushel.ToModelRepresentation();

            Assert.AreEqual(UnitOfMeasureDimensionEnum.PerVolume, representation.Dimension);
        }

        [Test]
        public void GivenEveryNumericRepresentationWithAUnitDimensionWhenToModelRepresentationThenDimensionMatchesTheUnitDimension()
        {
            var representations = RepresentationManager.Instance.Representations
                .OfType<NumericRepresentation>()
                .Where(r => r.UnitDimension != null)
                .ToList();

            Assert.IsNotEmpty(representations);

            foreach (var representation in representations)
            {
                var expected = representation.UnitDimension.DomainID.Substring(2);
                var actual = representation.ToModelRepresentation().Dimension.ToString();

                Assert.AreEqual(expected, actual, "Wrong dimension for " + representation.DomainId);
            }
        }
    }
}
