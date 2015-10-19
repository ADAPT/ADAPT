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

using System;
using System.Text;
using AgGateway.ADAPT.ApplicationDataModel;

namespace AgGateway.ADAPT.RepresentationTest.ClassGenerators
{
    public class RepresentationInstanceListGenerator : ClassGenerator
    {
        private const string RepresentationPattern = "        public static readonly {0} {2} = ({0})RepresentationManager.Instance.Representations[{1}];";

        protected override string Name
        {
            get
            {
                return "RepresentationInstanceList";
            }
        }

        protected override bool IsEnum
        {
            get
            {
                return false;
            }
        }

        protected override void Append(EnumeratedRepresentation definedRepresentation, StringBuilder stringBuilder)
        {
            stringBuilder.Append(String.Format(RepresentationPattern, typeof(EnumeratedRepresentation).Name, definedRepresentation.Id, definedRepresentation.Name));
            stringBuilder.Append("\n\n");
        }

        protected override void Append(VariableRepresentation representation, StringBuilder stringBuilder)
        {
            string representationName = representation.Name.Replace("\r", "")
                                                            .Replace("[", "")
                                                            .Replace("]", "")
                                                            .Replace("(", "")
                                                            .Replace(")", "")
                                                            .Replace("-", "")
                                                            .Replace("–", "")
                                                            .Replace(" ", "");

            stringBuilder.Append(String.Format(RepresentationPattern, typeof(VariableRepresentation).Name, representation.Id, representationName));
            stringBuilder.Append("\n\n");
        }
    }
}