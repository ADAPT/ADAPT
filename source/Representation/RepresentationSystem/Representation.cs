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
namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public abstract class Representation
    {
        public string DomainId { get; protected set; }
        public long DomainTag { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int? Ddi { get; protected set; }
        public bool IsDefaultRepresentationForDDI { get; protected set; }

        protected Representation(string domainId, long domainTag)
        {
            DomainTag = domainTag;
            DomainId = domainId;
        }

        public override string ToString()
        {
            return DomainId;
        }
    }
}
