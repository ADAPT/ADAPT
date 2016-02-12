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
  *    Justin Sliekers - renaming to Destination; removing GLN, ContactInfo and DestinationType; renaming name to description; adding location and facilityId
  *******************************************************************************/

using System;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Logistics
{
    public class Destination : MarshalByRefObject
    {
        public Destination()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; set; }

        public string Description { get; set; }
        
        public Location Location { get; set; }

        public int? FacilityId { get; set; }
    }
}
