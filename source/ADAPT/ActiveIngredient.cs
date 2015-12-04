/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Justin Sliekers, Kathleen Oneal - initial API and implementation
  *    Kathleen Oneal - Added parent class Ingredient and removed duplicate props
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class ActiveIngredient : Ingredient
    {
        public List<ModeOfAction> ModesOfAction { get; set; }
    }
}
