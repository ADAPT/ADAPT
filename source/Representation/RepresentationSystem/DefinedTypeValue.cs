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
namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public class DefinedTypeValue : ICopy<DefinedTypeValue>
    {
        public DefinedRepresentation Representation { get; private set; }
        public EnumerationMember EnumerationMember { get; set; }

        public DefinedTypeValue(string representationDomainId)
            : this((DefinedRepresentation)RepresentationManager.Instance.Representations[representationDomainId])
        {
            
        }

        public DefinedTypeValue(DefinedRepresentation definedRepresentation)
            : this(definedRepresentation, null)
        {
            
        }

        public DefinedTypeValue(string representationDomainId, string enumerationDomainId)
            : this((DefinedRepresentation)RepresentationManager.Instance.Representations[representationDomainId], ((DefinedRepresentation)RepresentationManager.Instance.Representations[representationDomainId]).EnumerationMembers[enumerationDomainId])
        {

        }

        public DefinedTypeValue(long representationDomainTag, long enumerationDomainTag) :
            this((DefinedRepresentation)RepresentationManager.Instance.Representations[representationDomainTag], ((DefinedRepresentation)RepresentationManager.Instance.Representations[representationDomainTag]).EnumerationMembers[enumerationDomainTag])
        {
            
        }

        public DefinedTypeValue(DefinedRepresentation definedRepresentation, EnumerationMember enumerationMember)
        {
            Representation = definedRepresentation;
            EnumerationMember = enumerationMember;
        }

        public override string ToString()
        {
            return EnumerationMember != null ? EnumerationMember.DomainId : string.Empty;
        }

        public DefinedTypeValue Copy()
        {
            return new DefinedTypeValue(Representation, EnumerationMember);
        }
    }
}
