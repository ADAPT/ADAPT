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

using AgGateway.ADAPT.ApplicationDataModel;
using NUnit.Framework;

namespace AgGateway.ADAPT.ApplicationDataModelTest
{
    [TestFixture]
    public class CompoundIdentifierFactoryTest
    {
        [Test]
        public void WhenMultipleCallsToInstanceShouldBeSingleton()
        {
            var factory1 = CompoundIdentifierFactory.Instance;
            var factory2 = CompoundIdentifierFactory.Instance;

            Assert.IsNotNull(factory1);
            Assert.AreSame(factory1, factory2);
        }

        [Test]
        public void WhenCreateThenCompoundIdentifierCreatedWithEmptyListOfUniqueIds()
        {
            var factory = CompoundIdentifierFactory.Instance;
            var identifier = factory.Create();

            Assert.IsEmpty(identifier.UniqueIds);
        }

        [Test]
        public void WhenCreateCalledMultipleTimesThenReferenceIdShouldIncrement()
        {
            var factory = CompoundIdentifierFactory.Instance;
            var identifier1 = factory.Create();
            var identifier2 = factory.Create();

            Assert.AreEqual(identifier1.ReferenceId + 1, identifier2.ReferenceId);
        }
    }
}
