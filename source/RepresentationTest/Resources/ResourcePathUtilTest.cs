/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Keith Reimer - initial API and implementation and/or initial documentation
  *******************************************************************************/

using System;
using System.IO;
using AgGateway.ADAPT.Representation.Resources;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.Resources
{
    [TestFixture]
    public class ResourcePathUtilTest
    {
        [Test]
        public void GivenFileShouldReturnFullPathSameAsCurrentDomainBaseDirectory()
        {
            var fileName = "test.xml";
            var expected = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ResourcePathUtil.ResourcesFolder, fileName);

            var result = ResourcePathUtil.FullResourcePath(fileName);

            Assert.AreEqual(expected, result);
        }
    }
}

