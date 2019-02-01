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

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Notes;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    /// <summary>
    /// Configuration for an irrigation system.
    /// Note that it inherits an Id, a Description, a DeviceElementId, and TimeScopes from its parent class.
    /// </summary>  
    public class IrrSystemConfiguration : DeviceElementConfiguration
    {
        public IrrSystemConfiguration()
        {
            SectionConfigurationIds = new List<int>();
            EndgunConfigurationIds = new List<int>();
            Notes = new List<Note>();
            ContextItems = new List<ContextItem>();
        }
        public Point SystemPosition { get; set; }

        public int? GrowerId { get; set; }

        public int? FarmId { get; set; }

        public int? FieldId { get; set; }

        public int? CropZoneId { get; set; }

        /// <summary>
        /// References to the Configurations of the system sections.
        /// </summary>  
        public List<int> SectionConfigurationIds { get; set; }
        
        /// <summary>
        /// This polygon is meant to represent the irrigated area of the whole system.
        /// </summary>
        public MultiPolygon SpatialFootprint { get; set; }
        
        /// <summary>
        /// This polyline is meant to represent the guidance path for a corner arm.
        /// </summary>
        public LineString GuidancePath { get; set; }

        /// <summary>
        /// If the system has a corner arm, is it leading or trailing?
        /// </summary>  
        public CornerArmTypeEnum CornerArmType { get; set; }

        /// <summary>
        /// Provides information about how the flow data is being generated: 
        /// flow data is read from a flow meter, estimated from an hour meter.
        /// </summary>  
        public IrrFlowDataSourceEnum FlowDataPedigree { get; set; }

        /// <summary>
        /// Provides information about how the system position data is being generated.
        /// </summary>  
        public GpsSourceEnum PositionDataPedigree { get; set; }

        /// <summary>
        /// Provides information about how the system event data is being generated.
        /// This can be useful in interpreting the perceived behavior of the system
        /// (e.g., a pivot appearing to speed up or slow down as a result of events
        /// being delayed but tagged with server time.)
        /// </summary>  
        public TimeDataSourceEnum TimeDataPedigree { get; set; }

        /// <summary>
        /// Useful for identifying systems and allocating water in FMIS. Optional.
        /// </summary>  
        public NumericRepresentationValue SystemLength { get; set; }

        /// <summary>
        /// Provides configuration information for any endguns
        /// </summary>  
        public List<int> EndgunConfigurationIds { get; set; }

        /// <summary>
        /// Pressure as it applies to the whole system when no other time-specific pressure values are available.
        /// </summary>
        public NumericRepresentationValue NominalPressure { get; set; } 

        /// <summary>
        /// Physical location in the system where the pressure is being measured.
        /// </summary>
        public IrrPressureLocationEnum PressureLocation { get; set; } 

        /// <summary>
        /// Efficiency as it applies to the whole system when no other section specific efficiency values are present
        /// and when no WorkRecord-specific values are given.
        /// </summary>
        public NumericRepresentationValue NominalEfficiency { get; set; }

        /// <summary>
        /// The nominal volume per unit time being delivered by the irrigation system.
        /// </summary>
        public NumericRepresentationValue NominalFlow { get; set; }   

        /// <summary>
        /// The time it takes a pivot to make a full circle at maximum speed.
        /// For partial circles, the time is for a full 360 degree rotation.
        /// </summary>
        public NumericRepresentationValue NominalFullCircleTime { get; set; }   

        /// <summary>
        /// Offset to convert (additively) from bearing reported by machine to
        /// actual compass bearing. IMPORTANT: this offset, if nonzero, will
        /// also act on plans, recommendations, and not just work orders
        // (this applies to *all* records).
        /// </summary>
        public NumericRepresentationValue BearingOffset { get; set; }

        public List<Note> Notes { get; set; }

        public List<ContextItem> ContextItems { get; set; }       
    }
}
