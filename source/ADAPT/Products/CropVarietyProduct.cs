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
  *    Joseph Ross Making Properties
  *    Kathleen Oneal - changed the list of traits to have ids instead of the object
  *    Stuart Rhea - Renamed from CropVariety to CropVarietyProduct per model
  *    Kelly Nelson - Appropriately initializing Product Type
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public class CropVarietyProduct : Product
    {
        public CropVarietyProduct()
        {
            TraitIds = new List<int>();
            ProductType = ProductTypeEnum.Variety;
        }

        public int CropId { get; set; }

        public List<int> TraitIds { get; set; }

        public bool GeneticallyEnhanced { get; set; }
    }
}
