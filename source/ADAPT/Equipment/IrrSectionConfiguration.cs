/*******************************************************************************
 * Copyright (C) 2018 AgGateway and ADAPT Contributors
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors:
 *    R. Andres Ferreyra - Adapted from S632-3 schema
 *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    /// <summary>
    /// Configuration for an irrigation system section.
    /// Note that it inherits an Id, a Description, a DeviceElementId, and TimeScopes from its parent class.
    /// </summary>  
    public class IrrSectionConfiguration : DeviceElementConfiguration
    {
        /// <summary>
        /// What kind of section is it? (Span, Endboom, Endgun, Corner, WrapBender, Fixed).
        /// </summary>  
        public IrrSectionTypeEnum SectionType { get; set; }

        /// <summary>
        /// InnerLength describes the distance from the proximal end of the section to the system reference point
        /// (e.g. pivot center). It is optional, and the meaning of its absence is context-dependent:
        /// a) In section 1, an absent InnerLength is assumed to have a value of 0. In subsequent sections
        /// an absent InnerLength is assumed to take the value of the previous section's OuterLength.
        /// </summary>  
        public NumericRepresentationValue InnerDistance { get; set; }

        /// <summary>
        /// In a single-section pivot system this value would equal the system length. Note that in a lateral system
        /// that has an endgun on the span of section 1, the corresponding endgun section would have a
        /// a 0 InnerDistance, and a negative OuterDistance.
        /// </summary>  
        public NumericRepresentationValue OuterDistance { get; set; }

        /// <summary>
        /// This element is optional, to accommodate non-radial footprints.
        /// This ability to provide a static spatial footprint for a section is meaningful only for a drip tape system
        /// or other stationary system.
        /// </summary>
        public MultiPolygon SpatialFootprint { get; set; }

        /// <summary>
        /// Default efficiency for the section.  When present, this value supersedes the system level NominalEfficiency.
        /// When IrrColllections or IrrItems specify efficiency, those values override this one.
        /// </summary>
        public NumericRepresentationValue NominalEfficiency { get; set; }
    }
}