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
    public class OMCode
    {
        public OMCode()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            CodeComponentIds = new List<int>();
            ContextItems = new List<ContextItem>();
        }
        public CompoundIdentifier Id { get; private set; }
        public string Code { get; set; }
        public string PId { get; set; }
        public string Description { get; set; }
        public List<int> CodeComponentIds { get; set; }       
        public List<ContextItem> ContextItems { get; set; }       
    }
}
