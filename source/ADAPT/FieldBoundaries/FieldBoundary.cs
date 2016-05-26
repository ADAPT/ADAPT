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
  *    Joseph Ross Making Properties
 *    Kathleen Oneal - made headland into a list of headlands
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries
{
    public class FieldBoundary
    {
        public FieldBoundary()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            Headlands = new List<Headland>();
            InteriorBoundaryAttributes = new List<InteriorBoundaryAttribute>();
            ContextItems = new List<ContextItem>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }
        
        public int FieldId { get; set; }
        
        public MultiPolygon SpatialData { get; set; }
        
        public List<int> TimeScopeIds { get; set; }
        
        public List<Headland> Headlands { get; set; }
        
        public GpsSourceEnum GpsSource { get; set; }
        
        public string OriginalEpsgCode { get; set; }
        
        public List<InteriorBoundaryAttribute> InteriorBoundaryAttributes { get; set; }
        
        public List<ContextItem> ContextItems { get; set; }
    }
}
