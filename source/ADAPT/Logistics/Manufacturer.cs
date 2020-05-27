/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * Copyright (C) 2020 SYngenta Crop Protection LLC
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *    Joseph Ross Making Properties
  *    Justin Sliekers - dropping context items
  *    Andres Ferreyra - 20200527 re-adding ContextItems; e.g., to support GLNs for ISO 11783 Annex E manufacturer Ids.  
  *******************************************************************************/

using System;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Logistics
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            ContextItems = new List<ContextItem>();            
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }
        
        public List<ContextItem> ContextItems { get; set; }        
    }
}
