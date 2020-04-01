/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Kathleen Oneal - initial API and implementation
  *    Kelly Nelson - Correcting RxShapeLookups initialization in constructor
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel.Prescriptions
{
    public class VectorPrescription : SpatialPrescription
    {
        public VectorPrescription()
        {
            RxShapeLookups = new List<RxShapeLookup>();
        }

        public List<RxShapeLookup> RxShapeLookups { get; set; }
    }
}
