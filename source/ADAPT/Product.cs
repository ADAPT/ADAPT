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
  *******************************************************************************/  

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public abstract class Product
    {
        public Product()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public int? ManufacturerId { get; set; }

        public int? BrandId { get; set; }

        public ProductTypeEnum ProductType { get; set; }

        public List<CategoryEnum> Categories { get; set; }

        public WorkStatusEnum WorkStatusEnum { get; set; }

        public List<ContextItem> ContextItems { get; set; }

        public ProductFormEnum Form { get; set; }

        public UnitOfMeasure DefaultUnit { get; set; }

        public NumericRepresentationValue Density { get; set; }
    }
}
