/*******************************************************************************
 * Copyright (C) 2019 AgGateway; PAIL and ADAPT Contributors
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors: 20190430 R. Andres Ferreyra: Translate from PAIL Part 2 Schema
 *               20190710 R. Andres Ferreyra: Added documentation
 *    
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class OMCode // Go-to way of expressing the meaning of an Obs (observation)
    {
        public OMCode()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            CodeComponentIds = new List<int>(); 
            ContextItems = new List<ContextItem>();
        }
        public CompoundIdentifier Id { get; private set; } // Each OmCode has its own CompoundIdentifier
        public string Code { get; set; }  // This is the key for key,value representations of an observation. 
        public string Description { get; set; } // Human-readable description of what the OMCode means.
        public List<int> CodeComponentIds { get; set; } // These are the units of meaning stat specify aspects of the OMCode's
          // meaning, such as feature of interest, observed property, observation method, aggregation method, etc.
        public List<ContextItem> ContextItems { get; set; }       
    }
}
