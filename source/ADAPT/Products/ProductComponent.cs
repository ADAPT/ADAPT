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
  *    Kelly Nelson - Added XML comments on members
  *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    /// <summary>
    /// An individual component that comprises part of a Product
    /// </summary>
    public class ProductComponent
    {
        /// <summary>
        /// IngredientId may refer to an Catalog Ingredient (crop nutrition element, active or inert chemical ingredient)
        /// or a Catalog Product (where the product itself is part of the mix, and it may have its own nested ingredients)
        /// While potentially confusing, this dual-meaning reference property was chosen early in the ADAPT project over the
        /// the option of having separate IngredientId and ProductId properties witout the ability to enforce only
        /// one or the other may be set.
        /// The IsProduct property below governs the type of object to which IngredientId refers
        /// </summary>
        public int IngredientId { get; set; }

        /// <summary>
        /// Quantity may be set in any appropriate Representation.
        /// E.g.s, vrProductContent, vrSolutionRateLiquid, vrActiveIngredientMassPerMass, etc.
        /// </summary>
        public NumericRepresentationValue Quantity { get; set; }

        /// <summary>
        /// True if the component refers to a Product, false if refers to an Ingredient
        /// </summary>
        public bool IsProduct { get; set; }

        /// <summary>
        /// True if this component represents the primary liquid contents of a mix
        /// </summary>
        public bool IsCarrier { get; set; }

        /// <summary>
        /// In what order was this component added to the mix? (1 = First).
        /// Can have duplicate numbers, representing a situation where two or more components are added simultaneously.
        /// </summary>
        public int? MixOrder { get; set; } 
    }
}
