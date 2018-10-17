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
using AgGateway.ADAPT.ApplicationDataModel.Notes;
using AgGateway.ADAPT.ApplicationDataModel.Products;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class IrrRecord
    {
        public IrrRecord()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            TimeScopes = new List<TimeScope>();
            PersonRoleIds = new List<int>();
            WorkItemIds = new List<int>();
            ProductUseSummaries = new List<ProductUse>();
            IrrSystemConfigurationIds = new List<int>();
            IrrSectionConfigurationIds = new List<int>();
            IrrCollectionIds = new List<int>();
            Notes = new List<Note>();
            ContextItems = new List<ContextItem>();
        }

        public CompoundIdentifier Id { get; private set; }

        public int WorkRecordId { get; set; }

        public List<TimeScope> TimeScopes { get; set; }

        public List<int> PersonRoleIds { get; set; }

        public List<int> WorkItemIds { get; set; }

        public int? GrowerId { get; set; }

        public int? FarmId { get; set; }

        public int? FieldId { get; set; }

        public int? CropZoneId { get; set; }

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
        /// Total irrigated area
        /// </summary>  
        public NumericRepresentationValue TotalArea { get; set; }
        
        /// <summary>
        /// Total water volume applied
        /// </summary>  
        public NumericRepresentationValue TotalWaterVolume { get; set; }
        
        public List<ProductUse> ProductUseSummaries { get; set; }

        public List<int> IrrSystemConfigurationIds { get; set; }

        public List<int> IrrSectionConfigurationIds { get; set; }

        public List<int> IrrCollectionIds { get; set; }

        public List<Note> Notes { get; set; }

        public List<ContextItem> ContextItems { get; set; }
    }
}
