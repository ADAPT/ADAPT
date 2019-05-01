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
using AgGateway.ADAPT.ApplicationDataModel.Documents;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class OMCollection
    {
        public OMCollection()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            CodeComponentIds = new List<int>();
            TimeScopes = new List<TimeScope>();
            ContextItems = new List<ContextItem>();
            OMCollections = new List<OMCollection>();
            OMs = new List<OM>();
        }
        public CompoundIdentifier Id { get; private set; }
        public int? OMSourceId { get; set; }
        public int? OMCodeId { get; set; }
        public List<int> CodeComponentIds { get; set; }       
        public List<TimeScope> TimeScopes { get; set; }
        public int? GrowerId { get; set; }
        public int? PlaceId { get; set; }
        public Point Position { get; set; }
        public List<OMCollection> OMCollections { get; set; } // Recursive!
        public List<OM> OMs { get; set; } 
            
        public List<ContextItem> ContextItems { get; set; }       
    }
}
