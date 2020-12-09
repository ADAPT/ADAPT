/*******************************************************************************
 * Copyright (C) 2019 AgGateway; PAIL and ADAPT Contributors
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors: 20190710 R. Andres Ferreyra: Translate from PAIL Part 2 Schema
 *    
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class Obs // Corresponds to the original PAIL OM; renamed for clarity.
    {
        public Obs()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            CodeComponentIds = new List<int>(); // List of code components to allow parameters, semantic refinement
            TimeScopes = new List<TimeScope>(); // PhenomenonTime / ResultTime / ValidityRange as per ISO 19156
            ContextItems = new List<ContextItem>();
        }
        public CompoundIdentifier Id { get; private set; }
        public int? OMSourceId { get; set; } // OMSource reduces Obs to (mostly) key,value pair even with sensors, installation 
        public int? OMCodeId { get; set; } // OMCode reduces Obs to (mostly) key,value pair when installation data is not needed
        public string OMCode { get; set; } // The string value provides the simplest form of meaning, by referring a pre-existing semantic resource by name (code).
        public List<int> CodeComponentIds { get; set; }  // List of code components refs to allow parameters, semantic refinement      
        public List<TimeScope> TimeScopes { get; set; }
        public int? GrowerId { get; set; } // Optional, provides ability to put an Obs in the context of a grower
        public int? PlaceId { get; set; } // Optional, provides ability to put an Obs in the context of a Place 
        public Shape SpatialExtent { get; set; } // Optional, includes Point, Polyline, and Polygon features of interest
        // Note: PlaceId provides a feature of interest by reference; SpatialExtent does so by value. They are not necessarily
        // mutually exclusive.  
        public string Value { get; set; } // The actual value of the observation. Its meaning is described by the OMCodeDefinition
        public string UoMCode { get; set; } // ADAPT codes for units of measure (e.g., "m1s-1" for meter/second) are required here.
         // PAIL allows different UoMAuthorities; but translation must happen in the PAIL plug-in level.

        public List<ContextItem> ContextItems { get; set; }       
    }
}
