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
    public class EnumerationMember : Representation
    {
        public EnumerationMember(RepresentationSystemRepresentationsDefinedTypeRepresentationDefinedTypeInstance definedTypeInstance)
            : this(definedTypeInstance, CultureInfo.CurrentUICulture)
        {

        }

        public EnumerationMember(RepresentationSystemRepresentationsDefinedTypeRepresentationDefinedTypeInstance definedTypeInstance, CultureInfo culture)
            : base(definedTypeInstance.domainID, definedTypeInstance.domainTag)
        {
            var name = GetName(definedTypeInstance.Name, culture);
            Name = name != null ? name.Value : null;
            Description = name != null ? name.description : null;
        }

        private static RepresentationSystemRepresentationsDefinedTypeRepresentationDefinedTypeInstanceName GetName(RepresentationSystemRepresentationsDefinedTypeRepresentationDefinedTypeInstanceName[] names, CultureInfo culture)
        {
            if (names == null)
                return null;

            return names.SingleOrDefault(n => n.locale == culture.TwoLetterISOLanguageName)
                ?? names.Single(n => n.locale == CultureInfoDefault.DefaultCulture);
        }
    }
}