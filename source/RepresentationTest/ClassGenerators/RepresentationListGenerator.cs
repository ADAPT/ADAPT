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

using System.Text;

namespace AgGateway.ADAPT.RepresentationTest.ClassGenerators
{
    public class RepresentationListGenerator : ClassGenerator
    {
        private const string RepresentationListPattern = "        {0} = {1},";

        protected override string Name
        {
            get
            {
                return "RepresentationList";
            }
        }

        protected override bool IsEnum
        {
            get
            {
                return true;
            }
        }

        protected override void Append(Representation.RepresentationSystem.EnumeratedRepresentation definedRepresentation, StringBuilder stringBuilder)
        {
            Append(definedRepresentation, stringBuilder);
        }

        protected override void Append(Representation.RepresentationSystem.NumericRepresentation representation, StringBuilder stringBuilder)
        {
            Append(representation, stringBuilder);
        }

        private void Append(Representation.RepresentationSystem.Representation representation, StringBuilder stringBuilder)
        {
            string representationName = representation.DomainId.Replace("\r", "")
                                                            .Replace("[", "")
                                                            .Replace("]", "")
                                                            .Replace("(", "")
                                                            .Replace(")", "")
                                                            .Replace("-", "")
                                                            .Replace("–", "")
                                                            .Replace(" ", "");
            stringBuilder.AppendFormat(RepresentationListPattern, representationName, representation.DomainTag);
            stringBuilder.Append("\n\n");
        }
    }
}