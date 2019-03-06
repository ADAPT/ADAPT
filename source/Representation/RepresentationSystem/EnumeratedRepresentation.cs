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
  *    Kelly Nelson - Added IsDefaultRepresentationForDDI
  *******************************************************************************/
using System.Globalization;
using System.Linq;
using AgGateway.ADAPT.Representation.Generated;

namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public class EnumeratedRepresentation : Representation
    {
        public RepresentationCollection<EnumerationMember> EnumerationMembers { get; private set; }

        public EnumeratedRepresentation(RepresentationSystemRepresentationsEnumeratedRepresentation enumeratedRepresentation)
            : this(enumeratedRepresentation, CultureInfo.CurrentUICulture)
        {

        }

        public EnumeratedRepresentation(RepresentationSystemRepresentationsEnumeratedRepresentation enumeratedRepresentation, CultureInfo culture)
            : base(enumeratedRepresentation.domainID, enumeratedRepresentation.domainTag)
        {
            EnumerationMembers = GetEnumerationMembers(enumeratedRepresentation);

            var name = GetName(enumeratedRepresentation.Name, culture);
            Name = name != null ? name.Value : null;
            Description = name != null ? name.description : null;
            if (enumeratedRepresentation.RelatedDDI != null)
            {
                Ddi = enumeratedRepresentation.RelatedDDI[0].ddi;
                if (enumeratedRepresentation.RelatedDDI.Any(d => d.isDefaultRepresentationForDDI))
                {
                    IsDefaultRepresentationForDDI = true;
                }
            }
        }

        private static RepresentationCollection<EnumerationMember> GetEnumerationMembers(RepresentationSystemRepresentationsEnumeratedRepresentation enumeratedRepresentation)
        {
            if (enumeratedRepresentation.Items == null)
            {
                return new RepresentationCollection<EnumerationMember>();
            }
            var enumerationMembers = enumeratedRepresentation.Items
                .OfType<RepresentationSystemRepresentationsEnumeratedRepresentationEnumeratedMember>()
                .Select(d => new EnumerationMember(d));
            return new RepresentationCollection<EnumerationMember>(enumerationMembers);
        }

        private static RepresentationSystemRepresentationsEnumeratedRepresentationName GetName(RepresentationSystemRepresentationsEnumeratedRepresentationName[] names, CultureInfo culture)
        {
            if (names == null)
                return null;

            return names.SingleOrDefault(n => n.locale == culture.TwoLetterISOLanguageName)
                ?? names.Single(n => n.locale == CultureInfoDefault.DefaultCulture);
        }
    }
}
