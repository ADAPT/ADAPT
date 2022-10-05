/*******************************************************************************
  * Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *    Tarak Reddy - Updated List of GuidanceId to List GuidanceAllocationId
  *    Tarak Reddy - Added parent document id that is required. A work item would have to exists as a Plan, Recommendation or WorkOrder.
  *    Kathleen Oneal - renamed ReferenceNoteIds to NoteIds; CropZoneId from list of ints to single int; renamed SpatialLayerIds to ReferenceLayerIds
  *    Justin Sliekers - implement device element changes
  *    Joseph Ross - removed ConnectorID added EquipmentConfigurationGroup
  *    Kelly Nelson - adding DataLogTriggers
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.Notes;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class WorkItem
    {
        public WorkItem()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            Notes = new List<Note>();
            TimeScopes = new List<TimeScope>();
            PeopleRoleIds = new List<int>();
            ReferenceLayerIds = new List<int>();
            WorkItemOperationIds = new List<int>();
            GuidanceAllocationIds = new List<int>();
            StatusUpdates = new List<StatusUpdate>();
            WorkOrderIds = new List<int>();
            DataLogTriggers = new List<LoggedData.DataLogTrigger>();
        }

        public CompoundIdentifier Id { get; private set; }
        
        public List<Note> Notes { get; set; }

        public List<TimeScope> TimeScopes { get; set; }
        
        public WorkItemPriorityEnum WorkItemPriority { get; set; }

        public List<int> PeopleRoleIds { get; set; }

        public int? GrowerId { get; set; }
        
        public int? FarmId { get; set; }

        public int? FieldId { get; set; }

        public int? CropZoneId { get; set; }
        
        public List<int> ReferenceLayerIds { get; set; }

        public int? BoundaryId { get; set; }

        public List<int> WorkItemOperationIds { get; set; }

        public List<int> GuidanceAllocationIds { get; set; }

        public List<StatusUpdate> StatusUpdates { get; set; }

        public List<int> WorkOrderIds { get; set; }

        public int ParentDocumentId { get; set; }

        public EquipmentConfigurationGroup EquipmentConfigurationGroup { get; set; }

        /// <summary>
        /// A DataLogTrigger is an ISO11783 concept prescribing what data should be logged by the devices performing the task (work item)
        /// </summary>
        public List<LoggedData.DataLogTrigger> DataLogTriggers { get; set; }
    }
}
