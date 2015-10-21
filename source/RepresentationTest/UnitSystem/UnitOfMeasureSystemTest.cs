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
using AgGateway.ADAPT.Representation.Generated;
using AgGateway.ADAPT.Representation.UnitSystem;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.UnitSystem
{
    [TestFixture]
    public class UnitOfMeasureSystemTest
    {
        private UnitSystemUnitOfMeasureSystem _unitOfMeasureSystem;
        private UnitSystemManager _unitSystemManager;

        [SetUp]
        public void Setup()
        {
            _unitOfMeasureSystem = new UnitSystemUnitOfMeasureSystem();
            _unitSystemManager = UnitSystemManager.Instance;
        }

        [Test]
        public void GivenUnitSystemWhenGetUnitSystemThenUnitSystem()
        {
            _unitOfMeasureSystem.domainID = "umsMetric";
            var unitSystem = new UnitOfMeasureSystem(_unitOfMeasureSystem, _unitSystemManager);
            Assert.AreEqual(Representation.UnitSystem.UnitSystem.umsMetric, unitSystem.UnitSystem);
        }

        [Test]
        public void GivenUnitOfMeasureSystemWhenGetUnitTypesThenUnitTypesAreLoaded()
        {
            _unitOfMeasureSystem.UnitOfMeasureRef = new[]
            {
                new UnitSystemUnitOfMeasureSystemUnitOfMeasureRef
                {
                    unitOfMeasureRef = "ft"   
                },
                new UnitSystemUnitOfMeasureSystemUnitOfMeasureRef
                {
                    unitOfMeasureRef = "gal"   
                }
            };
            var unitOfMeasureSystem = new UnitOfMeasureSystem(_unitOfMeasureSystem, _unitSystemManager);
            Assert.Contains(_unitSystemManager.UnitTypes["utDistance"], unitOfMeasureSystem.UnitTypes.ToList());
            Assert.Contains(_unitSystemManager.UnitTypes["utVolume"], unitOfMeasureSystem.UnitTypes.ToList());
        }
    }
}
