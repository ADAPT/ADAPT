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
using System.Reflection;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.PluginManager;
using Moq;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginManagerTest
{
   [TestFixture]
   public class PluginLoaderTest
   {
      private const String TestpluginDll = "AgGateway.ADAPT.TestPlugin.dll";
      private string _pluginDirectory;
      private string _pluginFileName;
      private Mock<IAssemblyResolver> _assemblyResolverMock;
      private PluginLoader _pluginLoader;

      [SetUp]
      public void Setup()
      {
         _pluginDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
         _pluginFileName = Path.Combine(_pluginDirectory, TestpluginDll);
         AssemblyWriter.WriteTestPlugin(_pluginDirectory, TestpluginDll);

         _assemblyResolverMock = new Mock<IAssemblyResolver>();
         _pluginLoader = new PluginLoader(_assemblyResolverMock.Object, typeof(IPlugin).FullName);
      }

      [Test]
      public void InspectAssemblyGivenPluginReturnsMetadata()
      {
         var assemblyMetadata = _pluginLoader.InspectAssembly(_pluginFileName);

         Assert.AreEqual("TestPlugin", assemblyMetadata.Name);
         Assert.AreEqual(Assembly.GetExecutingAssembly().GetName().Version, assemblyMetadata.ModelVersion);
         Assert.AreEqual(_pluginFileName, assemblyMetadata.AssemblyLocation);
         Assert.AreEqual("AgGateway.ADAPT.TestPlugin.TestPlugin", assemblyMetadata.EntryClass);
      }

      [Test]
      public void InspectAssemblyGivenRandomFileReturnsNull()
      {
         var assemblyMetadata = _pluginLoader.InspectAssembly(Path.GetTempFileName());
         Assert.IsNull(assemblyMetadata);
      }

      [Test]
      public void CreateInstanceGivenPluginReturnsEntryClass()
      {
         var metadata = _pluginLoader.InspectAssembly(_pluginFileName);
         var pluginInstance = _pluginLoader.CreateInstance(metadata);

         Assert.IsInstanceOf(typeof(IPlugin), pluginInstance);
      }

      [Test]
      public void CreateDependencyResolverShouldSavePluginDirectory()
      {
         _pluginLoader.SetupDependencyResolver(_pluginDirectory);
         _assemblyResolverMock.VerifySet(s => s.PluginDirectory = _pluginDirectory);
      }

      [Test]
      public void CreateDependencyResolverTwiceShouldOnlyRegisterOnce()
      {
         _pluginLoader.SetupDependencyResolver(_pluginDirectory);
         _pluginLoader.SetupDependencyResolver(_pluginDirectory);
         _assemblyResolverMock.VerifySet(s => s.PluginDirectory = _pluginDirectory, Times.Once());
      }

      [Test]
      public void InspectPluginGivenNoIPluginReturnsNull()
      {
         _pluginLoader = new PluginLoader(_assemblyResolverMock.Object, "IWharrgarbl");
         var result = _pluginLoader.InspectAssembly(_pluginFileName);

         Assert.IsNull(result);
      }

      [Test]
      public void PluginFactoryGivenEmptyDirectoryShouldHaveNoAvailablePlugins()
      {
         var pluginLocation = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
         var pluginLoader = new PluginFactory(pluginLocation);
         var result = pluginLoader.AvailablePlugins;

         Assert.IsEmpty(result);
      }

      [TearDown]
      public void TearDown()
      {
         try
         {
            File.Delete(_pluginFileName);
            Directory.Delete(_pluginDirectory);
         }
         catch (Exception)
         {
         }
      }
   }
}
