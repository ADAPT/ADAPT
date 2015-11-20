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
  *    Justin Sliekers - udpating DefinedRepresentation to EnumeratedRepresentation
  *******************************************************************************/

using System.Linq;
using System.Text;
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using EnumeratedRepresentation = AgGateway.ADAPT.ApplicationDataModel.EnumeratedRepresentation;
using NumericRepresentation = AgGateway.ADAPT.ApplicationDataModel.NumericRepresentation;

namespace AgGateway.ADAPT.RepresentationTest.ClassGenerators
{
    public interface IClassGenerator
    {
        string Generate();
    }

    public abstract class ClassGenerator : IClassGenerator
    {
        private const string NameSpace = "namespace AgGateway.ADAPT.Representation.RepresentationSystem\n{\n";
        private const string ClassNamePattern = "    public {0} {1} \n    ";
        private const string FileFooter = "    }\n}";
        protected abstract string Name
        {
            get;
        }
        protected abstract bool IsEnum
        {
            get;
        }

        public string Generate()
        {
//            var declaration = IsEnum ? "enum" : "class";
//            var classBuilder = new StringBuilder()
//                .Append("using AgGateway.ADAPT.ApplicationDataModel;\r\r")
//                .Append(NameSpace)
//                .AppendFormat(ClassNamePattern, declaration, Name)
//                .Append("{\n");
//
//            var definedRepresentations = RepresentationManager.Instance.Representations.Values.OfType<EnumeratedRepresentation>();
//            foreach (var definedRepresentation in definedRepresentations)
//            {
//                Append(definedRepresentation, classBuilder);
//            }
//
//            var numericRepresentations = RepresentationManager.Instance.Representations.Values.OfType<NumericRepresentation>();
//            foreach (var numericRepresentation in numericRepresentations)
//            {
//                Append(numericRepresentation, classBuilder);
//            }
//
//            classBuilder.Append(FileFooter);
//            return classBuilder.ToString();
            return string.Empty;
        }

        protected virtual void Append(NumericRepresentation representation, StringBuilder stringBuilder)
        {

        }

        protected virtual void Append(EnumeratedRepresentation definedRepresentation, StringBuilder stringBuilder)
        {

        }
    }
}