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
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel;

namespace AgGateway.ADAPT.Representation.RepresentationSystem.ExtensionMethods
{
    public static class RepresentationExtensions
    {
        public static NumericRepresentation ToModelRepresentation(this VariableRepresentation representation)
        {
            return new NumericRepresentation
            {
                Id = (int) representation.DomainTag,
                Name = representation.Name,
                Description = representation.Description,
            };
        }

        public static EnumeratedRepresentation ToModelRepresentation(this DefinedRepresentation representation)
        {
            return new EnumeratedRepresentation
            {
                Id = (int) representation.DomainTag,
                Name = representation.Name,
                Description = representation.Description,
                EnumeratedMembers = representation.EnumerationMembers.Select(m => m.ToModelEnumMember()).ToList()
            };
        }

        public static ApplicationDataModel.EnumerationMember ToModelEnumMember(this EnumerationMember enumMember)
        {
            return new ApplicationDataModel.EnumerationMember
            {
                Code = (int) enumMember.DomainTag,
                Value = enumMember.Name
            };
        }

        public static EnumerationMember ToInternalEnumMember(this EnumeratedValue enumMember)
        {
            var representation = enumMember.Representation.ToInternalRepresentation();
            return representation.EnumerationMembers.First(em => em.DomainTag == enumMember.Value.Code);
        }

        public static VariableRepresentation ToInternalRepresentation(this NumericRepresentation representation)
        {
            return (VariableRepresentation) RepresentationManager.Instance.Representations[representation.Id];
        }

        public static DefinedRepresentation ToInternalRepresentation(this EnumeratedRepresentation representation)
        {
            return (DefinedRepresentation) RepresentationManager.Instance.Representations[representation.Id];
        }
    }
}
