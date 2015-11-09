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
using System.Globalization;
using System.Linq;
using AgGateway.ADAPT.Representation.Generated;

namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public class DefinedRepresentation : Representation
    {
        public RepresentationCollection<EnumerationMember> EnumerationMembers { get; private set; }

        public DefinedRepresentation(RepresentationSystemRepresentationsDefinedTypeRepresentation definedTypeRepresentation)
            : this(definedTypeRepresentation, CultureInfo.CurrentUICulture)
        {

        }

        public DefinedRepresentation(RepresentationSystemRepresentationsDefinedTypeRepresentation definedTypeRepresentation, CultureInfo culture)
            : base(definedTypeRepresentation.domainID, definedTypeRepresentation.domainTag)
        {
            EnumerationMembers = GetEnumerationMembers(definedTypeRepresentation);

            var name = GetName(definedTypeRepresentation.Name, culture);
            Name = name != null ? name.Value : null;
            Description = name != null ? name.description : null;
        }

        private static RepresentationCollection<EnumerationMember> GetEnumerationMembers(RepresentationSystemRepresentationsDefinedTypeRepresentation definedTypeRepresentation)
        {
            if (definedTypeRepresentation.Items == null)
            {
                return new RepresentationCollection<EnumerationMember>();
            }
            var enumerationMembers = definedTypeRepresentation.Items
                .OfType<RepresentationSystemRepresentationsDefinedTypeRepresentationDefinedTypeInstance>()
                .Select(d => new EnumerationMember(d));
            return new RepresentationCollection<EnumerationMember>(enumerationMembers);
        }

        private static RepresentationSystemRepresentationsDefinedTypeRepresentationName GetName(RepresentationSystemRepresentationsDefinedTypeRepresentationName[] names, CultureInfo culture)
        {
            if (names == null)
                return null;

            return names.SingleOrDefault(n => n.locale == culture.TwoLetterISOLanguageName)
                ?? names.Single(n => n.locale == CultureInfoDefault.DefaultCulture);
        }
    }
}