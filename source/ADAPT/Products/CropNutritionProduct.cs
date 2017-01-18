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
  *    Kathleen Oneal - added periodic, IsManure, FulvicAcid, and Humic Acid properties
  *    Stuart Rhea - Renamed from FertilizerProduct to CropNutritionProduct per model
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public class CropNutritionProduct : Product
    {
        public bool IsManure { get; set; }
    }
}
