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
using System.Collections.Generic;

namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public class RepresentationGroup 
    {
        private readonly Dictionary<long, Representation> _representations;
 
        public RepresentationGroupList RepresentationGroupList { get; private set; }

        public IEnumerable<Representation> Representations
        {
            get { return _representations.Values; }
        } 

        public int DomainID
        {
            get  { return (int)RepresentationGroupList; }
        }

        public RepresentationGroup(RepresentationGroupList representationGroupList)
        {
            _representations = new Dictionary<long, Representation>();
            RepresentationGroupList = representationGroupList;
        }

        protected void Add(Representation representation)
        {
            _representations.Add(representation.DomainTag, representation);
        }

        public bool IsMember(string domainId)
        {
            var representation = RepresentationManager.Instance.Representations[domainId];
            return IsMember(representation.DomainTag);
        }

        public bool IsMember(Representation representation)
        {
            return IsMember(representation.DomainTag);
        }

        private bool IsMember(long domainTag)
        {
            return _representations.ContainsKey(domainTag);
        }
    }
}
