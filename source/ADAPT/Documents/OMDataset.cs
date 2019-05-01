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

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class OMDataset
    {
        public OMDataset()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            TimeScopes = new List<TimeScope>();
            ContextItems = new List<ContextItem>();
            OMCollections = new List<OMCollection>();
        }
        public CompoundIdentifier Id { get; private set; }
        public string Description { get; set; }
        public string SetupURL { get; set; }
        public UnitOfMeasureAuthorityEnum? UnitOfMeasureAuthority { get; set; }
        public List<TimeScope> TimeScopes { get; set; }   
        public List<OMCollection> OMCollections { get; set; }
        public List<ContextItem> ContextItems { get; set; }       
    }
}
