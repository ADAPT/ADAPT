/*******************************************************************************
 * Copyright (C) 2019 AgGateway; PAIL and ADAPT Contributors
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors: 20190430 R. Andres Ferreyra: Translate from PAIL Part 2 Schema
 *    
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class ObsCollection
    {
        public ObsCollection()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            CodeComponentIds = new List<int>();  // List of code components that apply to all child Obs in the collection
            TimeScopes = new List<TimeScope>(); // List of TimeScopes that apply to all child Obs in the collection
            ContextItems = new List<ContextItem>();
            ObsCollectionIds = new List<int>(); // Note: these are references to ObsCollections in Documents
            ObsIds = new List<int>();  // Note: these are references to Obs in Documents
        }
        public CompoundIdentifier Id { get; private set; }
        public int? OMSourceId { get; set; } // OMSource reduces child Obs to (mostly) key,value pair even with sensors, installation 
        public int? OMCodeId { get; set; } // OMCode reduces child Obs to (mostly) key,value pair when installation data is not needed
        public string OMCode { get; set; } // The string value provides the simplest form of meaning, by referring a pre-existing semantic resource by name (code).
        public List<int> CodeComponentIds { get; set; }  // List of code components refs to allow parameters, semantic refinement      
        public List<TimeScope> TimeScopes { get; set; }
        public int? GrowerId { get; set; } // Optional, provides ability to put an ObsCollection in the context of a grower
        public int? PlaceId { get; set; } // Optional, provides ability to put an ObsCollection in the context of a Place 
        public Shape SpatialExtent { get; set; } // Optional, includes Point, Polyline, and Polygon features of interest
        // Note: PlaceId provides a feature of interest by reference; SpatialExtent does so by value. They are not necessarily
        // mutually exclusive.  

        public List<int> ObsCollectionIds { get; set; } // Recursive!
        public List<int> ObsIds { get; set; } 
            
        public List<ContextItem> ContextItems { get; set; }       
    }
}
