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

using System.Collections.Generic;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using Moq;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.RepresentationSystem
{
    [TestFixture]
    public class RepresentationCollectionTest
    {
        [Test]
        public void GivenRepresentationsWhenIndexedByDomainIdThenRepresentation()
        {
            var representations = new List<Representation.RepresentationSystem.Representation>
            {
                CreateRepresentation("vrHarvestMoisture", 4),
                CreateRepresentation("vrYieldWetMass", 5),
                CreateRepresentation("vrYieldMass", 6),
                CreateRepresentation("dtSignalType", 3)
            };
            var collection = new RepresentationCollection<Representation.RepresentationSystem.Representation>(representations);
            Assert.AreSame(representations[2], collection["vrYieldMass"]);
        }

        [Test]
        public void GivenRepresentationsWhenIndexedByDomainTagThenRepresentation()
        {
            var representations = new List<Representation.RepresentationSystem.Representation>
            {
                CreateRepresentation("vrYieldWetMass", 5),
                CreateRepresentation("vrHarvestMoisture", 4),
                CreateRepresentation("vrYieldMass", 6),
                CreateRepresentation("dtSignalType", 3)
            };
            var collection = new RepresentationCollection<Representation.RepresentationSystem.Representation>(representations);
            Assert.AreSame(representations[1], collection[4]);
        }

        [Test]
        public void GivenRepresentationsWhenCreatedThenCountAvailable()
        {
            var representations = new List<Representation.RepresentationSystem.Representation>
            {
                CreateRepresentation("vrHarvestMoisture", 4),
                CreateRepresentation("vrYieldWetMass", 5),
                CreateRepresentation("dtSignalType", 3)
            };
            var collection = new RepresentationCollection<Representation.RepresentationSystem.Representation>(representations);
            Assert.AreEqual(3, collection.Count);
        }

        [Test]
        public void GivenRepresentationsWhenEnumeratedThenAllRepresentationsAreEnumerated()
        {
            var representations = new List<Representation.RepresentationSystem.Representation>
            {
                CreateRepresentation("vrHarvestMoisture", 4),
                CreateRepresentation("vrYieldWetMass", 5),
                CreateRepresentation("vrYieldMass", 6),
                CreateRepresentation("dtSignalType", 3)
            };
            var collection = new RepresentationCollection<Representation.RepresentationSystem.Representation>(representations);
            Assert.AreEqual(4, collection.Count);
        }

        [Test]
        public void GivenDomainIdNotInCollectionWhenIndexedThenReturnsNull()
        {
            var representations = new List<Representation.RepresentationSystem.Representation>
            {
                CreateRepresentation("vrHarvestMoisture", 4),
                CreateRepresentation("vrYieldWetMass", 5),
                CreateRepresentation("dtHitchType", 3)
            };
            var collection = new RepresentationCollection<Representation.RepresentationSystem.Representation>(representations);
            var representation = collection["dtSignalType"];
            Assert.IsNull(representation);
        }

        [Test]
        public void GivenDomainTagNotInCollectionWhenIndexedThenReturnsNull()
        {
            var representations = new List<Representation.RepresentationSystem.Representation>
            {
                CreateRepresentation("vrHarvestMoisture", 4),
                CreateRepresentation("vrYieldWetMass", 5),
                CreateRepresentation("dtSignalType", 3)
            };
            var collection = new RepresentationCollection<Representation.RepresentationSystem.Representation>(representations);
            var representation = collection[9];
            Assert.IsNull(representation);
        }
        private static Representation.RepresentationSystem.Representation CreateRepresentation(string domainId, long domainTag)
        {
            var representationMock = new Mock<Representation.RepresentationSystem.Representation>(domainId, domainTag)
            {
                CallBase = true
            };
            return representationMock.Object;
        }
    }
}
