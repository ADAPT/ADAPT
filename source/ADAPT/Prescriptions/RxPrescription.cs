/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Justin Sliekers - initial API and implementation
  *    Kathleen Oneal - Renamed ShapeLookups to RxShapeLookups and changed type to List<RxShapeLookup> from List<ShapeLookup>
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel.Prescriptions
{
    public class RxPrescription : SpatialPrescription
    {
        public List<RxShapeLookup> RxShapeLookups { get; set; } 
    }
}
