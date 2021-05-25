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
    public void GivenUnitSystemManagerWhenGetInstanceThenUnitSystemManagerIsCreated()
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
  }
}
