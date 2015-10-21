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
using AgGateway.ADAPT.PluginManager;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginManagerTest
{
    [TestFixture]
    public class FileSystemTest
    {
        private FileSystem _fileSystem;
        private string _directoryLocation;

        [SetUp]
        public void Setup()
        {
            _fileSystem = new FileSystem();
            _directoryLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        }

        [Test]
        public void GetFilesGivenPathRetrievesFiles()
        {
            var result = _fileSystem.GetFiles(_directoryLocation, "*");
            Assert.Greater(result.Count(), 0);
            foreach (var file in result)
            {
                Assert.IsTrue(File.Exists(file));
            }
        }

        [Test]
        public void GetFilesGivenSearchPatternShouldApplyPattern()
        {
            var result = _fileSystem.GetFiles(_directoryLocation, "*.dll");
            foreach (var file in result)
            {
                Assert.IsTrue(file.EndsWith(".dll", StringComparison.InvariantCultureIgnoreCase));
            }
        }

        [Test]
        public void GetFilesGivenNonExistingPathShouldReturnEmptyList()
        {
            _directoryLocation = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var result = _fileSystem.GetFiles(_directoryLocation, "*.*");
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetSubDirectoriesGivenPathShouldReturnEmptyList()
        {
            var result = _fileSystem.GetSubDirectories(_directoryLocation);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetSubDirectoriesGivenPathShouldReturnTwoDirectories()
        {
            var subDirectory1 = Path.Combine(_directoryLocation, Guid.NewGuid().ToString());
            Directory.CreateDirectory(subDirectory1);

            var subDirectory2 = Path.Combine(_directoryLocation, Guid.NewGuid().ToString());
            Directory.CreateDirectory(subDirectory2);
            try
            {
                var result = _fileSystem.GetSubDirectories(_directoryLocation);
                Assert.AreEqual(2, result.Count);
            }
            finally
            {
                Directory.Delete(subDirectory1);
                Directory.Delete(subDirectory2);
            }
        }

        [Test]
        public void GetSubDirectoriesGivenEmptyPathShouldReturnEmptyList()
        {
            var result = _fileSystem.GetSubDirectories(string.Empty);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetSubDirectoriesGivenNonExistantDirectoryShouldReturnEmptyList()
        {
            _directoryLocation = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            var result = _fileSystem.GetSubDirectories(_directoryLocation);
            Assert.IsEmpty(result);
        }
    }
}
