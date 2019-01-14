﻿/*******************************************************************************
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

using AgGateway.ADAPT.Representation.RepresentationSystem;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest.RepresentationSystem
{
  [TestFixture]
  public class RepresentationManagerTest
  {
    [Test]
    public void GivenRepresentationManagerWhenGetInstanceThenRepresentationManagerIsCreated()
    {
      var instance = RepresentationManager.Instance;
      Assert.IsNotNull(instance);
    }

    [Test]
    public void GivenRepresentationManagerWhenGetInstanceThenSameInstanceIsReturned()
    {
      var firstInstance = RepresentationManager.Instance;
      var secondInstance = RepresentationManager.Instance;
      Assert.AreSame(firstInstance, secondInstance);
    }
  }
}
