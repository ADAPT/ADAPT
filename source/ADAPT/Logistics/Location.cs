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
  *    Kathleen Oneal - added GpsSource
  *    R. Andres Ferreyra - added nullable ParentFacilityId for PAIL compatibility.
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Logistics
{
    public class Location
    {
        public Location()
        {
            ContextItems = new List<ContextItem>();
        }

        public Point Position { get; set; }
        
        public List<ContextItem> ContextItems { get; set; }
        
        public GpsSource GpsSource { get; set; }
        
        public int? ParentFacilityId { get; set; } // Locations in PAIL have Ids; they don't in ADAPT. This provides a way to
                                                   // enable using ADAPT facilities to stand in for Locations (by reference) when needed.         
    }
}
