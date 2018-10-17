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
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    /// <summary>
    /// This class describes the applied water / product(s) on a list of sections, having a common time interval, and possibly start/end angle.
    /// </summary>  
    public class IrrItem
    {
        public IrrItem()
        {
            TimeScopes = new List<TimeScope>();
            SectionFlows = new List<IrrSectionFlow>();
            FlowTags = new List<IrrFlowTagEnum>();
        }

        /// <summary>
        /// Actual Start date/time and End date/time for the irrigated region being described.
        /// </summary>  
        public List<TimeScope> TimeScopes { get; set; }

        /// <summary>
        /// Describes the spatial scope of the irrigation item.
        /// </summary>  
        public IrrSpatialScope SpatialScope { get; set; }

        /// <summary>
        /// Describes whether chemigation and/or fertigation are happening.
        /// </summary>  
        public List<IrrFlowTagEnum> FlowTags { get; set; }

        /// <summary>
        /// Used to define a local center of rotation for the IrrItem. 
        /// Unlikely to be used.: in a work record or other finer-granularity
        /// document this would be declared at the IrrCollection level.
        /// </summary>  
        public Point RotCtr { get; set; }

        /// <summary>
        /// Describes water and products applied to the different sections.
        /// </summary>  
        public List<IrrSectionFlow> SectionFlows { get; set; }

        /// <summary>
        /// The average pressure as recorded during the execution of Work Record
        /// within the scope of this particular IrrItem
        /// </summary>  
        public NumericRepresentationValue Pressure { get; set; }

        /// <summary>
        /// Error Code if something went wrong.
        /// </summary>  
        public IrrErrorCodeEnum ErrorCode { get; set; }

        /// <summary>
        /// The estimated efficiency of this application for this particular IrrItem.
        /// This value overrides the EstimatedEfficiency specified for the IrrCollection
        /// and the values specified in the IrrSetup.
        /// </summary>  
        public NumericRepresentationValue EstimatedEfficiency { get; set; }

    }
}