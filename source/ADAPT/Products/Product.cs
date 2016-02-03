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
  *    Kathleen Oneal - changed Name to Description
  *    Kathleen Oneal - renamed ProductTypeEnum to ProductType
  *    Justin Sliekers - dropping nullable from manufacturerId and brandId; dropping collection off Category; removing defaultUnit and WorkStatusEnum
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public abstract class Product
    {
        protected Product()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public int BrandId { get; set; }

        public CategoryEnum Category { get; set; }
        
        public List<ContextItem> ContextItems { get; set; }

        public NumericRepresentationValue Density { get; set; }

        public string Description { get; set; }

        public ProductFormEnum Form { get; set; }

        public int ManufacturerId { get; set; }

        public List<ProductComponent> ProductComponents { get; set; }

        public ProductTypeEnum ProductType { get; set; }

        public ProductStatusEnum Status { get; set; }
    }
}
