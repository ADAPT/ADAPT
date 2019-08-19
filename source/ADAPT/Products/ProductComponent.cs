/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * Copyright (C) 2019 Syngenta
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tim Shearouse - initial API and implementation
  *    R. Andres Ferreyra - Added MixOrder, as requested for Mix Ticket "Product Group" compatibility.
  *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public class ProductComponent
    {
        public int IngredientId { get; set; }

        public NumericRepresentationValue Quantity { get; set; }

        public bool IsProduct { get; set; }

        public bool IsCarrier { get; set; }
        
        public int? MixOrder { get; set; } // In what order was this component added to the mix? (1 = First).
        // Can have duplicate numbers, representing a situation where two or more components are added simultaneously.
    }
}
