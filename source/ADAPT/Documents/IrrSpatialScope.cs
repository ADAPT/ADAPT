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

using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    /// <summary>
    /// This class describes either a radial, or a multipolygon spatial scope
    /// for the purposes of specifying an amount of irrigation water / products.
    /// </summary>  
    public class IrrSpatialScope
    {
        /// <summary>
        /// Specify using radial start/end angle notation (inner/outer radii are provided by the sections).
        /// Used for center pivots.
        /// </summary>  
        public IrrRadialSpatialScope RadialScope { get; set; }

        /// <summary>
        /// Specify using a multipolygon: good for stationary suystems.
        /// </summary>  
        public MultiPolygon MultiPolygonScope { get; set; }
    }
}
