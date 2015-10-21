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
using AgGateway.ADAPT.PluginManager;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginManagerTest
{
    [TestFixture]
    public class AssemblyResolverTests
    {
        private const string TestpluginDll = "TestPlugin.dll";
        private string _pluginDirectory;
        private AssemblyResolver _resolver;

        [SetUp]
        public void Setup()
        {
            _pluginDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            AssemblyWriter.WriteTestPlugin(_pluginDirectory, TestpluginDll);
            _resolver = new AssemblyResolver { PluginDirectory = _pluginDirectory };
        }

        [Test]
        public void AssemblyResolverGivenInvalidClassNameReturnsNull()
        {
            var result = _resolver.LoadFromPluginDirectory(null, new ResolveEventArgs("Bad Assembly Name"));

            Assert.IsNull(result);
        }

        [Test]
        public void AssemblyResolverGivenValidClassNameReturnsAssembly()
        {
            var result = _resolver.LoadFromPluginDirectory(null, new ResolveEventArgs("TestPlugin"));

            Assert.AreEqual("Adapt.TestPlugin", result.GetName().Name);
        }
    }
}
