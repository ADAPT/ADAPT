/*******************************************************************************
  * Copyright (C) 2015, 2018 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel.Prescriptions
{
    public class RadialPrescription : SpatialPrescription
    {
        public RadialPrescription()
        {
            RadialLookupCollections = new List<RadialLookupCollection>();
        }

        public List<RadialLookupCollection> RadialLookupCollections { get; set; }
    }
}
