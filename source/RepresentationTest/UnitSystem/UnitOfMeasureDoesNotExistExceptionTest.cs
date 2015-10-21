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

using AgGateway.ADAPT.Representation.UnitSystem;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.UnitSystem
{
    [TestFixture]
    public class UnitOfMeasureDoesNotExistExceptionTest
    {
        [Test]
        public void GivenUnitOfMeasureWhenCreatedThenUnitOfMeasure()
        {
            var exception = new UnitOfMeasureDoesNotExistException("");
            Assert.IsEmpty(exception.UnitOfMeasure);
        }

        [Test]
        public void GivenUnitOfMeasureWhenCreatedThenMessageContainsUnitOfMeasure()
        {
            var exception = new UnitOfMeasureDoesNotExistException("NotAUnit");
            Assert.AreEqual("NotAUnit unit of measure does not exist.", exception.Message);
        }
    }
}
