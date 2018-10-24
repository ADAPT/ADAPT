/*******************************************************************************
 * Copyright (C) 2018 AgGateway and ADAPT Contributors
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors:
 *    R. Andres Ferreyra - Adapting from PAIL S632-3 schema.
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Products;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    /// <summary>
    /// This class describes the applied water / product(s) on the footprint of a section during a certain temporal / spatial scope.
    /// Note that the time is not specified within the class, but rather in its IrrItem wrapper. 
    /// </summary>  
    public class IrrSectionFlow
    {
        public IrrSectionFlow()
        {
            ProductUses = new List<ProductUse>();
        }

        /// <summary>
        /// References the section of interest.
        /// </summary>  
        public int SectionId { get; set; }

        /// <summary>
        /// Describes the total volume of water put on the section during the spatial and temporal scope of interest.
        /// Not necessary if Depth is populated, but declaring both is fine.
        /// </summary>  
        public NumericRepresentationValue Volume { get; set; }

        /// <summary>
        /// Describes the irrigation depth (in units of distance) put on the section during the spatial and temporal scope of interest.
        /// Not necessary if Volume is populated, but declaring both is fine.
        /// </summary>  
        public NumericRepresentationValue Depth { get; set; }

        /// <summary>
        /// Optional list describing the amount of product(s) such as chemicals, fertilizers, energy, etc. used.
        /// </summary>  
        public List<ProductUse> ProductUses { get; set; }

        /// <summary>
        /// This multipolygon documents the coverage area for a) irregular coverages on pivots such as corner arms and wraps/benders, 
        /// b) laterals. and c) Traveling guns. Although it can conceivably be used to document the coverage of pivot spans, 
        /// using radial scope of the parent IrrItem along with section number is much more compact.
        /// </summary>  
        public MultiPolygon PolygonCoverage { get; set; }

    }
}