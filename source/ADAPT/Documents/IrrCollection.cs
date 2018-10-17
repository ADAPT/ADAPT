/*******************************************************************************
 * Copyright (C) 2018 AgGateway and ADAPT Contributors
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors:
 *    R. Andres Ferreyra - Adapted from PAIL S632-3 schema.
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    /// <summary>
    /// This class describes the applied water / product(s) on a list of IrrItems.
    /// </summary>  
    public class IrrCollection
    {
        public IrrCollection()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            TimeScopes = new List<TimeScope>();
            FlowTags = new List<IrrFlowTagEnum>();
            IrrItems = new List<IrrItem>();
        }

        public CompoundIdentifier Id { get; private set; }
        
        /// <summary>
        /// Actual Start date/time and End date/time for the irrigated region being described.
        /// </summary>  
        public List<TimeScope> TimeScopes { get; set; }

        /// <summary>
        /// The RadialScope element expresses the start/end angle of a radial irrigated region.
        /// The InnerDistance and OuterDistance defined at the section levels, and referenced
        /// via the section IDs, provide a very compact shorthand way of completing the
        /// representation of the spatial coverage of most pivot sections.
        /// The PolygonScope element is never used here: spatial coverage of pivot corner arms,
        /// pivot wraps/benders, laterals, and traveling guns should be expressed as polygons
        /// at the section level. Spatial coverage of tape sections is defined in the section
        /// setup, so the section ID should suffice to describe coverage.
        /// </summary>  
        public IrrSpatialScope SpatialScope { get; set; }

        /// <summary>
        /// This is a simple mechanism for communicating information about the record: was the system chemigating?
        /// Was it fertigating? This list could conceivably grow in future versions. Note that, while chemigation
        /// and fertigation tags seem redundant inn the context of product use reporting at the section level,
        /// the reality of irrigation monitoring systems at the time of this writing is that specific products can
        /// usually not be documented before the data is processed in an FMIS. These flags provide the FMIS operator
        /// with a warning that additional data entry is needed.
        /// </summary>  
        public List<IrrFlowTagEnum> FlowTags { get; set; }

        /// <summary>
        /// Used to define a local center of rotation for the IrrCollection. 
        /// </summary>  
        public Point RotCtr { get; set; }

        /// <summary>
        /// This is the sequence of documented irrigated "pie slices" of a pivot,
        /// or their counterparts for the irrigation system type in question.
        /// </summary>  
        public List<IrrItem> IrrItems { get; set; }

        /// <summary>
        /// The average pressure as recorded during the execution of Work Record
        /// within the scope of this particular IrrItem
        /// </summary>  
        public NumericRepresentationValue Pressure { get; set; }

        /// <summary>
        /// The estimated efficiency of this application for this particular IrrItem.
        /// This value overrides the EstimatedEfficiency specified for the IrrCollection
        /// and the values specified in the IrrSetup.
        /// </summary>  
        public NumericRepresentationValue EstimatedEfficiency { get; set; }

    }
}
