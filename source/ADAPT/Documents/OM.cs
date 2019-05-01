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
    public class OM
    {
        public OM()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            CodeComponentIds = new List<int>();
            TimeScopes = new List<TimeScope>();
            ContextItems = new List<ContextItem>();
        }
        public CompoundIdentifier Id { get; private set; }
        public int? OMSourceId { get; set; }
        public int? OMCodeId { get; set; }
        public List<int> CodeComponentIds { get; set; }       
        public List<TimeScope> TimeScopes { get; set; }
        public int? GrowerId { get; set; }
        public int? PlaceId { get; set; }
        public Point Position { get; set; }
        public string Value { get; set; }
        public string UoMCode { get; set; } // ADAPT codes by default;
         // a different UoMAuthority may be declared at the OMDataset or Observations level.

        public List<ContextItem> ContextItems { get; set; }       
    }
}
