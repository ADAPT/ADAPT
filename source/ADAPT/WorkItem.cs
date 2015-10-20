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
  *******************************************************************************/  

using System;
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
        public List<int> RecommendationdIds { get; set; }
        public List<int> WorkOrderIds { get; set; }
        public List<int> NoteIds { get; set; }
        public Priority Priority { get; set; }
        public List<int> TimeScopeIds { get; set; }
        public List<int> PeopleRoleIds { get; set; }
        public int? GrowerId { get; set; }
        public int? FarmId { get; set; }
        public int? FieldId { get; set; }
        public List<int> CropZoneId { get; set; }
        public int? MachineId { get; set; }
        public List<int> SpatialLayerIds { get; set; }
        public int? FieldBoundaryId { get; set; }
        public List<int> WorkItemOperationIds { get; set; }
        public List<int> GuidanceIds { get; set; }
        public List<StatusUpdate> StatusUpdates { get; set; }
    }
}