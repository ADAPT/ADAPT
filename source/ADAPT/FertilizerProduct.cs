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
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class FertilizerProduct : Product
    {
        public List<IngredientUse> Ingredients { get; set; }

        public NumericValue N { get; set; }

        public double? P { get; set; }

        public double? K { get; set; }

        public double? Ca { get; set; }

        public double? Mg { get; set; }
        
        public double? S { get; set; }

        public double? B { get; set; }

        public double? Cl { get; set; }

        public double? Cu { get; set; }

        public double? Fe { get; set; }

        public double? Mn { get; set; }

        public double? Mo { get; set; }

        public double? Zn { get; set; }

        public bool IsManure { get; set; }

        public NumericValue FulvicAcid { get; set; }

        public NumericValue HumicAcid { get; set; }
    }
}
