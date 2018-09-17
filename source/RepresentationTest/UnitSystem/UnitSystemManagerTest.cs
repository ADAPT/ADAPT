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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using AgGateway.ADAPT.Representation;
using AgGateway.ADAPT.Representation.Generated;
using AgGateway.ADAPT.Representation.UnitSystem;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.UnitSystem
{
    [TestFixture]
    public class UnitSystemManagerTest
    {
        [Test]
        public void GivenUnitSystemManagerWhenGetInstanceThenRepresentationManagerIsCreated()
        {
            var instance = InternalUnitSystemManager.Instance;
            Assert.IsNotNull(instance);
        }

        [Test]
        public void GivenUnitSystemManagerWhenGetInstanceThenSameInstanceIsReturned()
        {
            var firstInstance = InternalUnitSystemManager.Instance;
            var secondInstance = InternalUnitSystemManager.Instance;
            Assert.AreSame(firstInstance, secondInstance);
        }

        [Test]
        public void GivenXmlShouldLoadUnits()
        {
            foreach (var unit in DeserializeUnitSystem().UnitDimensions.SelectMany(
                    ut => ut.Items.OfType<UnitSystemUnitDimensionUnitDimensionRepresentation>()
                                  .SelectMany(utr => utr.UnitOfMeasure)))
            {
                var unitOfMeasure = (ScalarUnitOfMeasure) InternalUnitSystemManager.Instance.UnitOfMeasures[unit.domainID];

                Assert.AreEqual(unit.baseOffset, unitOfMeasure.BaseOffset);
                Assert.AreEqual(unit.scale, unitOfMeasure.Scale);
            }
        }

        [Test]
        public void GivenXmlShouldLoadUnitsUnderTypes()
        {
            foreach (var unit in DeserializeUnitSystem().UnitDimensions.SelectMany(
                    ut => ut.Items.OfType<UnitSystemUnitDimensionUnitDimensionRepresentation>()
                                  .SelectMany(utr => utr.UnitOfMeasure)))
            {
                var unitOfMeasure = (ScalarUnitOfMeasure) InternalUnitSystemManager.Instance.UnitDimensions.SelectMany(x => x.Units).First(y => y.DomainID == unit.domainID);
                Assert.AreEqual(unit.scale, unitOfMeasure.Scale);
                Assert.AreEqual(unit.baseOffset, unitOfMeasure.BaseOffset);
                Assert.AreEqual(unit.Name.First(n => n.locale == CultureInfoDefault.DefaultCulture).label, unitOfMeasure.Label);
            }
        }

        [Test]
        public void GivenXmlShouldLoadunitDimensions()
        {
            foreach (var unitDimension in DeserializeUnitSystem().UnitDimensions)
            {
                var matchingType = InternalUnitSystemManager.Instance.UnitDimensions[unitDimension.domainID];
                var expected = unitDimension.Items.OfType<UnitSystemUnitDimensionUnitDimensionRepresentation>().SelectMany(x => x.UnitOfMeasure);
                Assert.AreEqual(expected.Count(), matchingType.Units.Count);
                Assert.AreEqual(unitDimension.Name.First(n => n.locale == CultureInfoDefault.DefaultCulture).Value, matchingType.Name);
            }
        }

        [Test]
        public void GivenXmlShouldLoadUnitOfMeasureSystems()
        {
            foreach (var unitOfMeasureSystem in DeserializeUnitSystem().UnitOfMeasureSystems)
            {
                AgGateway.ADAPT.Representation.UnitSystem.UnitSystem unitSystem;
                if (Enum.TryParse(unitOfMeasureSystem.domainID, out unitSystem))
                {
                    var system = InternalUnitSystemManager.Instance.UnitOfMeasureSystems[unitSystem];
                    var units = system.UnitDimensions.SelectMany(x => x.Units).Select(x => x.DomainID).Distinct().ToList();
                    foreach (var unitDomainId in unitOfMeasureSystem.UnitOfMeasureRef.Select(x => x.unitOfMeasureRef))
                    {
                        Assert.IsTrue(units.Contains(unitDomainId));
                    }
                }
            }
        }

        [Test]
        public void GivenXmlWhenGetUnitsOfMeasureThenUnitOfMeasureCollection()
        {
            var unitSystemManager = InternalUnitSystemManager.Instance;
            Assert.IsInstanceOf<UnitOfMeasureCollection>(unitSystemManager.UnitOfMeasures);
        }

        [Test]
        public void GivenTwoScalarUnitsWhenDivideUnitsShouldReturnNewComposite()
        {
            var firstUnit = InternalUnitSystemManager.Instance.UnitOfMeasures["m"];
            var secondUnit = InternalUnitSystemManager.Instance.UnitOfMeasures["sec"];

            var result = InternalUnitSystemManager.Instance.CombineUnitsAsFraction(firstUnit, secondUnit);

            Assert.AreEqual("m1sec-1", result.DomainID);
        }

        [Test]
        public void GivenTwoCompositeUnitsWhenDivideUnitsShouldReturnNewComposite()
        {
            var firstUnit = InternalUnitSystemManager.Instance.UnitOfMeasures["m2"];
            var secondUnit = InternalUnitSystemManager.Instance.UnitOfMeasures["cm3"];

            var result = InternalUnitSystemManager.Instance.CombineUnitsAsFraction(firstUnit, secondUnit);

            Assert.AreEqual("[m2]1[cm3]-1", result.DomainID);
        }

        private Representation.Generated.UnitSystem DeserializeUnitSystem()
        {
            var assemblyLocation = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            var unitSystemXml = Path.Combine(assemblyLocation, "Resources", "UnitSystem.xml");
            var serializer = new XmlSerializer(typeof(Representation.Generated.UnitSystem));
            using (var stream = File.OpenRead(unitSystemXml))
                return (Representation.Generated.UnitSystem)serializer.Deserialize(stream);
        }
    }
}
