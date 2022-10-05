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

using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    /// <summary>
    /// This class describes the start/end angles (assuming clockwise motion)
    /// of a radial "pie slice" (e.g., a center pivot irrigation system).
    /// </summary>  
    public class IrrRadialSpatialScope
    {
        /// <summary>
        /// Start angle of the "pie slice" being described, assuming clockwise motion.
        /// </summary>  
        public NumericRepresentationValue StartAngle { get; set; }

        /// <summary>
        /// End angle of the "pie slice" being described, assuming clockwise motion.
        /// </summary>  
        public NumericRepresentationValue EndAngle { get; set; }
    }
}