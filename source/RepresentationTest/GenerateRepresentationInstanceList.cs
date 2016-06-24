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

using System.IO;
using AgGateway.ADAPT.RepresentationTest.ClassGenerators;
using NUnit.Framework;

namespace AgGateway.ADAPT.RepresentationTest
{
    [TestFixture]
    public class GenerateRepresentationInstanceList
    {
        [Test]
        [Ignore("Used to generate representation list")]
        public void GivenRepresentationManagerGenerateRepresentationInstanceList()
        {
            var representationSystemDirectory = Path.GetTempPath();
            var path = Path.Combine(representationSystemDirectory, "RepresentationInstanceList.cs");
            GenerateClass(path, new RepresentationInstanceListGenerator());

            path = Path.Combine(representationSystemDirectory, "RepresentationTagList.cs");
            GenerateClass(path, new RepresentationTagListGenerator());

            path = Path.Combine(representationSystemDirectory, "DefinedTypeInstanceList.cs");
            GenerateClass(path, new DefinedTypeInstanceListGenerator());

            path = Path.Combine(representationSystemDirectory, "DefinedTypeEnumerationInstanceList.cs");
            GenerateClass(path, new DefinedTypeEnumerationInstanceListGenerator());

            path = Path.Combine(representationSystemDirectory, "RepresentationList.cs");
            GenerateClass(path, new RepresentationListGenerator());

            path = Path.Combine(representationSystemDirectory, "RepresentationGroupInstanceList.cs");
            GenerateClass(path, new RepresentationGroupInstanceListGenerator());
        }

        //[Test]
        //public void GivenRepresentationWhenGetInstancesThenInstancesMatchDomainIds()
        //{
        //    foreach (var field in typeof(RepresentationInstanceList).GetFields())
        //    {
        //        var value = (ApplicationDataModel.Representation)field.GetValue(null);
        //        Assert.AreEqual(field.Name, value.DomainId);
        //    }
        //}

        private static void GenerateClass(string filePath, IClassGenerator generator)
        {
            var classString = generator.Generate();
            File.WriteAllText(filePath, classString);
        }

        private static string GetRepresentationSystemPath(string currentDirectory)
        {
            if (currentDirectory.EndsWith("ADAPT"))
                return Path.Combine(currentDirectory, "Representation", "RepresentationSystem");

            var parentDirectory = new DirectoryInfo(currentDirectory).Parent.FullName;
            return GetRepresentationSystemPath(parentDirectory);
        }
    }
}
