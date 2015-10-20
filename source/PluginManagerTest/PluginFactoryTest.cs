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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.PluginManager;
using Moq;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginManagerTest
{
    [TestFixture]
    public class PluginFactoryTest
    {
        private Mock<IFileSystem> _filesystem;
        private Mock<IPluginLoader> _pluginLoader;
        private PluginFactory _pluginFactory;
        private PluginMetadata _pluginMetadata;
        private string _pluginDirectory;
        private string _assemblyLocation;
        private Mock<IPlugin> _mockPlugin;

        [SetUp]
        public void SetUp()
        {
            _pluginDirectory = @"C:\Temp\Plugins";
            _assemblyLocation = Path.Combine(_pluginDirectory, "TestPlugin.dll");
            _filesystem = new Mock<IFileSystem>();
            _filesystem.Setup(x => x.GetFiles(_pluginDirectory, "*.dll")).Returns(new[] { _assemblyLocation });
            _filesystem.Setup(s => s.GetSubDirectories(_pluginDirectory)).Returns(new List<string>());

            _pluginMetadata = BuildMetadata("1.0.0.0", "TestPlugin");

            _pluginLoader = new Mock<IPluginLoader>();
            _mockPlugin = new Mock<IPlugin>();
            _pluginLoader.Setup(x => x.CreateInstance(_pluginMetadata)).Returns(_mockPlugin.Object);
            _pluginLoader.Setup(x => x.InspectAssembly(_assemblyLocation)).Returns(_pluginMetadata);

            _pluginFactory = new PluginFactory(_filesystem.Object, _pluginDirectory, _pluginLoader.Object);
        }

        [Test]
        public void AvailablePluginsGivenDllReturnsName()
        {
            var plugins = _pluginFactory.AvailablePlugins;

            var enumerable = plugins.ToArray();
            Assert.AreEqual(1, enumerable.Count());
            Assert.AreEqual(_pluginMetadata.Name, enumerable.First());
        }

        [Test]
        public void LoadPluginsShouldOnlyBeCalledOnce()
        {
            var availablePlugins = _pluginFactory.AvailablePlugins;

            Assert.AreEqual(1, availablePlugins.Count());
            _pluginLoader.Verify(x => x.InspectAssembly(_assemblyLocation), Times.Once());
        }

        [Test]
        public void GetPluginShouldInitializePlugin()
        {
            var plugin = _pluginFactory.GetPlugin(_pluginMetadata.Name);

            _pluginLoader.Verify(x => x.CreateInstance(_pluginMetadata));
            Assert.AreSame(_pluginMetadata.AssemblyInstance, plugin);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void GetPluginGivenBadNameThrowsException()
        {
            _pluginFactory.GetPlugin("SomethingThatDoesNotExist");
        }

        [Test]
        public void GetPluginMultipleTimesShouldInstantiateOnlyOnce()
        {
            _pluginFactory.GetPlugin(_pluginMetadata.Name);
            _pluginFactory.GetPlugin(_pluginMetadata.Name);

            _pluginLoader.Verify(x => x.CreateInstance(_pluginMetadata), Times.Once());
        }

        [Test]
        public void ShouldRegisterDependencyResolverOnLoad()
        {
            _pluginLoader.Verify(x => x.SetupDependencyResolver(_pluginDirectory), Times.Once());
        }

        [Test]
        public void ShouldRegisterDependendcyResolverAsCurrentDirectory()
        {
            _pluginDirectory = null;
            _filesystem.Setup(s => s.GetFiles(Directory.GetCurrentDirectory(), "*.dll")).Returns(new List<string>());

            new PluginFactory(_filesystem.Object, _pluginDirectory, _pluginLoader.Object);
            _pluginLoader.Verify(s => s.SetupDependencyResolver(Directory.GetCurrentDirectory()), Times.Once());
        }
        
        [Test]
        public void AvailablePluginsShouldGetPluginsFromSubDirectory()
        {
            var subDirectories = new List<string>
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            };
            _filesystem.Setup(s => s.GetSubDirectories(_pluginDirectory)).Returns(subDirectories);
            _filesystem.Setup(s => s.GetFiles(subDirectories[0], "*.dll")).Returns(new List<string>());
            _filesystem.Setup(s => s.GetFiles(subDirectories[1], "*.dll")).Returns(new List<string>());

            _pluginFactory.AvailablePlugins.ToList();
            _filesystem.Verify(s => s.GetFiles(subDirectories[0], "*.dll"), Times.Once());
            _filesystem.Verify(s => s.GetFiles(subDirectories[1], "*.dll"), Times.Once());
        }

        private PluginMetadata BuildMetadata(string modelVersion, string pluginName)
        {
            return new PluginMetadata
            {
                EntryClass = "Plugin",
                AssemblyLocation = _assemblyLocation,
                Name = pluginName,
                ModelVersion = new Version(modelVersion)
            };
        }
    }
}
