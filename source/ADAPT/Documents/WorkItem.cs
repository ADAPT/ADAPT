/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
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
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class WorkItem
    {
        public WorkItem()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }
        
        public List<int> PlanIds { get; set; }
        
        public List<int> RecommendationIds { get; set; }
        
        public List<int> WorkOrderIds { get; set; }
        
        public List<int> NoteIds { get; set; }
        
        public WorkItemPriorityEnum WorkItemPriority { get; set; }
        
        public List<int> TimeScopeIds { get; set; }
        
        public List<int> PeopleRoleIds { get; set; }
        
        public int? GrowerId { get; set; }
        
        public int? FarmId { get; set; }
        
        public int? FieldId { get; set; }
        
        public int? CropZoneId { get; set; }
        
        public int? MachineId { get; set; }
        
        public List<int> ReferenceLayerIds { get; set; }
        
        public int? BoundaryId { get; set; }
        
        public List<int> WorkItemOperationIds { get; set; }
        
        public List<int> GuidanceAllocationIds { get; set; }
        
        public List<StatusUpdate> StatusUpdates { get; set; }
        
        public int ParentDocumentId { get; set; }
    }
}