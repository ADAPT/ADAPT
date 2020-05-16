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
    public class ObsDataset // A dataset, containing a collection of ObsCollections
    {
        public ObsDataset()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            TimeScopes = new List<TimeScope>();
            ContextItems = new List<ContextItem>();
            ObsCollectionIds = new List<int>(); // Note that ObsCollection is a recursive structure, to accommodate  
              // multiple use cases that require different depths of organization.
        }
        public CompoundIdentifier Id { get; private set; }
        public string Description { get; set; } // Human-friendly description of the dataset
        public string SetupURL { get; set; } // PAIL legacy, a URL pointing to  setup data.
        // public UnitOfMeasureAuthorityEnum? UnitOfMeasureAuthority { get; set; } Agreed to force ADAPT UoMs; PAIL plug-in should translate 
        public List<TimeScope> TimeScopes { get; set; } // Dataset-specific timescopes (e.g., create date, start & end, etc.)    
        public List<int> ObsCollectionIds { get; set; } // List of references to the ObsCollections contained in the dataset
        public List<ContextItem> ContextItems { get; set; }       
    }
}
