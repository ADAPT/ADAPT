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
  *    Joseph Ross - Renaming Enums to end in Enum
  *    Kathleen Oneal - added values
  *    Kathleen Oneal - added unknown value
  *    Kathleen Oneal - added variety value
  *    Kathleen Oneal - added Additive, GrowthRegulator, Insecticide, and NitrogenStabilizer values
  *    Kathleen Oneal - added Carrier
  *    Jason Roesbeke - added Fertilizer & Pesticide
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public enum CategoryEnum
    {
        Additive,
        Carrier,
        Fungicide,
        GrowthRegulator,
        Insecticide,
        Herbicide,
        Manure,
        NitrogenStabilizer,
        Unknown,
        Variety,
        Fertilizer, //non-manure
        Pesticide, //non-Insecticide
    }
}
