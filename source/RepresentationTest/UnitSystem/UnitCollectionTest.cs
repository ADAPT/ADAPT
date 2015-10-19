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
using System.Collections.Generic;
using System.Linq;
using AgGateway.ADAPT.Representation.UnitSystem;
using Moq;
using NUnit.Framework;

namespace JohnDeere.RepresentationTest.UnitSystem
{
    [TestFixture]
    public class UnitCollectionTest
    {
        [Test]
        public void GivenListOfUnitsWhenIndexedByDomainIdThenUnit()
        {
            var units = CreateUnits("mm", "m", "in");
            var collection = new UnitCollection<IUnit>(units);
            Assert.AreSame(units[1], collection["m"]);
        }

        [Test]
        public void GivenListWithDuplicateUnitsWWhenCreatedThenDuplicatesAreRemoved()
        {
            var units = CreateUnits("mm", "m", "mm");
            var collecion = new UnitCollection<IUnit>(units);
            Assert.AreEqual(2, collecion.Count);
        }

        [Test]
        public void GivenListOfUnitsWhenCreatedThenCountIsAvailable()
        {
            var units = CreateUnits("m", "ac", "mm");
            var collection = new UnitCollection<IUnit>(units);
            Assert.AreEqual(3, collection.Count);
        }

        [Test]
        public void GivenListOfUnitsWhenEnmeratedThenAllUnitsAreEnumerated()
        {
            var units = CreateUnits("m", "ft", "mm", "in", "cm");
            var collection = new UnitCollection<IUnit>(units);
            var actual = collection.Count();
            Assert.AreEqual(5, actual);
        }

        [Test]
        public void GivenDomainIdNotInUnitsWhenIndexedThenNull()
        {
            var units = CreateUnits("m", "mm");
            var collection = new UnitCollection<IUnit>(units);
            var unit = collection["ft"];

            Assert.IsNull(unit);
        }

        private static List<IUnit> CreateUnits(params string[] domainIds)
        {
            return domainIds.Select(CreateUnit).ToList();
        }

        private static IUnit CreateUnit(string domainId)
        {
            var unitMock = new Mock<IUnit>();
            unitMock.Setup(s => s.DomainID).Returns(domainId);
            return unitMock.Object;
        }
    }
}
