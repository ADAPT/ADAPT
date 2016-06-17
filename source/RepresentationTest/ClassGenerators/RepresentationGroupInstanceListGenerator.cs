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
using System.Linq;
using System.Text;
using AgGateway.ADAPT.Representation.RepresentationSystem;

namespace AgGateway.ADAPT.RepresentationTest.ClassGenerators
{
       public class RepresentationGroupInstanceListGenerator : IClassGenerator
       {
           private const string NameSpace = "namespace JohnDeere.Representation.RepresentationSystem\n{\n";
           private const string ClassName = "    public class RepresentationGroupInstanceList \n    ";
           private const string RepresentationGroupInstanceListPattern = "        public static readonly RepresentationGroup {0} = RepresentationGroups.Instance.GetGroup(RepresentationGroupList.{0});\n\n";
           private const string FileFooter = "    }\n}";
   
           public string Generate()
           {
               var classBuilder = new StringBuilder()
                   .Append(NameSpace)
                   .AppendFormat(ClassName)
                   .Append("{\n");
   
               foreach (var group in Enum.GetValues(typeof(RepresentationGroupList)).Cast<RepresentationGroupList>())
               {
                   classBuilder.AppendFormat(RepresentationGroupInstanceListPattern, group);
               }
               classBuilder.Append(FileFooter);
               return classBuilder.ToString();
           }
       }
}
