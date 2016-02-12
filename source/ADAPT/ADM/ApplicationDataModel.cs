/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *    Kathleen Oneal - changed ReferenceLayers type from ReferenceLayers to List<ReferenceLayer>
  *******************************************************************************/

using System;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;

namespace AgGateway.ADAPT.ApplicationDataModel.ADM
{
    public class ApplicationDataModel : MarshalByRefObject
    {
        public List<ProprietaryValue> ProprietaryValues { get; set; }

        public Catalog Catalog { get; set; }

        public Documents Documents { get; set; }

        public List<ReferenceLayer> ReferenceLayers { get; set; }
    }
}