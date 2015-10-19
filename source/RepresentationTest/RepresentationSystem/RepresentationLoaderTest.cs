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

using System.Linq;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.RepresentationSystem
{
    [TestFixture]
    public class RepresentationLoaderTest
    {
        private RepresentationLoader _representationLoader;

        [SetUp]
        public void Setup()
        {
            _representationLoader = new RepresentationLoader();
        }

        [Test]
        public void GivenNoParamsWhenLoadThenLoadsAllDdiEntries()
        {
            var result = _representationLoader.Load();

            Assert.AreEqual(420, result.Values.Count);
        }

        [Test]
        public void GivenDdiEntryWhenLoadThenSetsId()
        {
            var result = _representationLoader.Load(DdiDefinition);

            Assert.AreEqual(7, result.Values.Single().Id);
        }

        [Test]
        public void GivenDdiEntryWhenLoadThenSetsName()
        {
            var result = _representationLoader.Load(DdiDefinition);

            Assert.AreEqual("Actual Mass Per Area Application Rate", result.Values.Single().Name);
        }

        [Test]
        public void GivenDdiEntryWhenLoadThenSetsDescription()
        {
            var result = _representationLoader.Load(DdiDefinition);

            Assert.AreEqual("Actual Application Rate specified as mass per area", result.Values.Single().Description);
        }

        private const string DdiDefinition = "\n\nDD Entity: 7 Actual Mass Per Area Application Rate\nDefinition: Actual Application Rate specified as mass per area\nComment: \nTypically used by Device Classes: \n4 - Planters /Seeders\n5 - Fertilizer\n6 - Sprayers\n10 - Irrigation\nUnit: mg/m² - Mass per area unit\nResolution: 1\nSAE SPN: not specified\nRange: 0 - 2147483647\nSubmit by: Part 10 Task Force\nSubmit Date: 2003-08-01\nSubmit Company: 89 - Kverneland Group, Electronics Division\nRevision Number: 1\nCurrent Status: ISO-Published\nStatus Date: 2005-02-02\nStatus Comments: DDEs have been moved to published for creating the new Annex A version.\nAttachments: \nnone\n\n";
    }
}
