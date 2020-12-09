/*******************************************************************************
 * Copyright (C) 2020 AgGateway; PAIL and ADAPT Contributors
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors: 20201208 R. Andres Ferreyra: Translate from PAIL Part 2 Schema
 *    
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class ObsCodeComponent // Corresponds to the original PAIL OMCodeComponent; renamed for clarity.
    {
        public ObsCodeComponent()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }
        public CompoundIdentifier Id { get; private set; }
        public string ComponentCode { get; set; } // Provides a code that represents the meaning of this Code Component (code).
        public string PId { get; set; }  // Persistent identifier (presumed a URI) for this CodeComponent     
        public string Description { get; set; }  // Human-readable description of what the CodeComponent means
        public string ComponentType { get; set; } // What kind of CodeComponent is this? A parameter, feature of interest, observed property...? 
        public string Selector { get; set; } // A second leavel of meaning for the code component. Usually from a controlled vocabulary. 
        public string Value { get; set; } // A third level of meaning for the code component. May be enumerated or not. 
        public string ValueUoMCode { get; set; } // An optional unit of measure code that qualifies the value. 
           // ADAPT codes for units of measure (e.g., "m1s-1" for meter/second) are required here.
           // PAIL allows different UoMAuthorities; but translation must happen in the PAIL plug-in level.
        public OMCodeComponentValueTypeEnum ValueType { get; set; } // Specifies the data type (e.g., integer, boolean) of the value. 
    }
}
