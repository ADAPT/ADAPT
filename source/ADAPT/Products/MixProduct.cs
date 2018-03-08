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
  *    Joseph Ross - added IsHotMix to match uml
  *    Stuart Rhea - Renamed from ProductMix to MixProduct per model
  *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public class MixProduct : Product
    {
        public NumericRepresentationValue TotalQuantity { get; set; }

        public bool IsTemporary { get; set; }

        public bool IsHotMix { get; set; }
    }
}
