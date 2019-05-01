/*******************************************************************************
  * Copyright (C) 2019 AgGateway, ADAPT Contributors, and Syngenta
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    20190319: R. Andres Ferreyra - Created class from Traceability WG and PAIL work 
  *******************************************************************************/
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Logistics
{
    // Place enables specifying where something is/was/will be, with varying degrees of detail.
    // Initially planned for use when specifying actions performed with containers, and With PAIL OM.

    public class Place
    {
        public Place()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            ContextItems = new List<ContextItem>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }
 
        /// <summary>
        /// PlaceType property. </summary>
        /// <value>
        /// This declares what class the Place is standing in for (e.g., Position, Container, etc. This value is required. Note that "Mixed" is an option.</value>
        public PlaceTypeEnum PlaceType { get; set; }

        public int? DeviceElementId { get; set; }
        public int? ContainerId { get; set; }
        public int? FarmId { get; set; }
        public int? FieldId { get; set; }
        public int? CropZoneId { get; set; }
        public int? FacilityId { get; set; }
        public MultiPolygon MultiPolygon { get; set; }
        public LineString LineString { get; set; }
        public Location Location { get; set; }
        public Point Position { get; set; }

        /// <summary>
        /// ContextItems property. </summary>
        /// <value>
        /// Optional list of ContextItem objects.</value>
        public List<ContextItem> ContextItems { get; set; }
    }
}