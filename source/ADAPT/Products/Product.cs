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
  *    Joseph Ross - Added HasCrop.. Protection, Nutrition, Variety and HasHarvestCommodity to match the uml
  *    Stuart Rhea - Modified Product.BrandId and Product.ManufacturerId to be nullable (int?) per model.
  *    Kelly Nelson - Added SpecificGravity
  *    Kelly Nelson - Initializing Form
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
            ContextItems = new List<ContextItem>();
            ProductComponents = new List<ProductComponent>();
            Form = ProductFormEnum.Unknown; //Handle the unfortunate placement of Unknown in the form enum so that all products don't initialize as Gas.
        }

        public CompoundIdentifier Id { get; private set; }

        public int? BrandId { get; set; }

        public CategoryEnum Category { get; set; }
        
        public List<ContextItem> ContextItems { get; set; }

        /// <summary>
        /// The density of the product (mass per volume)
        /// </summary>
        public NumericRepresentationValue Density { get; set; }

        /// <summary>
        /// A unitless specific gravity ratio
        /// </summary>
        public double? SpecificGravity { get; set; }

        public string Description { get; set; }

        public ProductFormEnum Form { get; set; }

        public bool HasCropProtection { get; set; }

        public bool HasCropNutrition { get; set; }

        public bool HasCropVariety { get; set; }

        public bool HasHarvestCommodity { get; set; }

        public int? ManufacturerId { get; set; }

        public List<ProductComponent> ProductComponents { get; set; }

        public ProductTypeEnum ProductType { get; set; }

        public ProductStatusEnum Status { get; set; }
    }
}
