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
  *    Kathleen Oneal - moved machineId and guidanceAllocationIds from workRecord to this
  *    Kathleen Oneal - changed OperationDataIds to WorkItemIds
  *    Joseph Ross - Added list of person roles and container uses
  *    Joseph Ross - Added EquipmentConfigurationGroup
  *    Joseph Ross - inherits document
  *    Joseph Ross - removed inhertance from document added needed properties
  *    Joseph Ross - added Id
 *    Joseph Ross - renaming person roles, and timescopes
  *******************************************************************************/

using System;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.Notes;

namespace AgGateway.ADAPT.ApplicationDataModel.LoggedData
{
    public class LoggedData
    {
        public LoggedData()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            WorkItemIds = new List<int>();
            Notes = new List<Note>();
            GuidanceAllocationIds = new List<int>();
            TimeScopes = new List<TimeScope>();
        }

        public CompoundIdentifier Id { get; private set; }

        public List<int> WorkItemIds { get; set; } 

        public List<Note> Notes { get; set; } 

        public List<int> GuidanceAllocationIds { get; set; }

        public int? FarmId { get; set; }

        public int? FieldId { get; set; }

        public int? GrowerId { get; set; }

        public int? CropZoneId { get; set; }

        public List<int> PersonRoleIds { get; set; }

        public IEnumerable<OperationData> OperationData { get; set; }

        public int? SummaryId { get; set; }

        public List<int> ContainerUseIDs { get; set; }

        public Action ReleaseSpatialData { get; set; }

        public EquipmentConfigurationGroup EquipmentConfigurationGroup { get; set; }

        public List<TimeScope> TimeScopes { get; set; }

        public string Description { get; set; }
    }
}