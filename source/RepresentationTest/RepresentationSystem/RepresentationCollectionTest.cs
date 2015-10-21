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
            var representations = new List<ApplicationDataModel.Representation>
            {
                CreateRepresentation(6, "Setpoint Application Rate specified as mass per area", "Setpoint Mass Per Area Application Rate"),
                CreateRepresentation(7, "Actual Application Rate specified as mass per area", "Actual Mass Per Area Application Rate"),
                CreateRepresentation(8, "Default Application Rate specified as mass per area", "Default Mass Per Area Application Rate"),
                CreateRepresentation(9, "Minimum Application Rate specified as mass per area", "Minimum Mass Per Area Application Rate")
            };
            var collection = new RepresentationCollection<ApplicationDataModel.Representation>(representations);
            Assert.AreSame(representations[1], collection[7]);
        }

        [Test]
        public void GivenRepresentationsWhenCreatedThenCountAvailable()
        {
            var representations = new List<ApplicationDataModel.Representation>
            {
                CreateRepresentation(6, "Setpoint Application Rate specified as mass per area", "Setpoint Mass Per Area Application Rate"),
                CreateRepresentation(7, "Actual Application Rate specified as mass per area", "Actual Mass Per Area Application Rate"),
                CreateRepresentation(8, "Default Application Rate specified as mass per area", "Default Mass Per Area Application Rate")
            };
            var collection = new RepresentationCollection<ApplicationDataModel.Representation>(representations);
            Assert.AreEqual(3, collection.Count);
        }

        [Test]
        public void GivenDomainIdNotInCollectionWhenIndexedThenReturnsNull()
        {
            var representations = new List<ApplicationDataModel.Representation>
            {
                CreateRepresentation(6, "Setpoint Application Rate specified as mass per area", "Setpoint Mass Per Area Application Rate"),
                CreateRepresentation(7, "Actual Application Rate specified as mass per area", "Actual Mass Per Area Application Rate")
            };
            var collection = new RepresentationCollection<ApplicationDataModel.Representation>(representations);
            var representation = collection[9000];
            Assert.IsNull(representation);
        }

        private static ApplicationDataModel.Representation CreateRepresentation(int domainId, string description, string name)
        {
            var representation = new ApplicationDataModel.NumericRepresentation
            {
                Id = domainId,
                Description = description,
                Name = name,
            };
            return representation;
        }
    }
}
