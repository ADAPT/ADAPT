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
  *    Kathleen Oneal - removed implementConfigId and machineConfigId, added EquipmentConfigId
  *    Justin Sliekers - implement device element changes
  *    Joseph Ross - Added EquipmentConfigurationGroup
  *	   Jason Roesbeke - added Description    
  *******************************************************************************/

using System;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;

namespace AgGateway.ADAPT.ApplicationDataModel.LoggedData
{
    public class OperationData
    {
        public OperationData()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            EquipmentConfigurationIds = new List<int>();
        }

        public CompoundIdentifier Id { get; private set; }
        
        public int? LoadId { get; set; }

        public OperationTypeEnum OperationType { get; set; }

        public int? PrescriptionId { get; set; }

        public List<int> ProductId { get; set; }

        public int? VarietyLocatorId { get; set; }

        public int? WorkItemOperationId { get; set; }

        public int MaxDepth { get; set; }

        public int SpatialRecordCount { get; set; }

        public List<int> EquipmentConfigurationIds { get; set; } 

        public Func<IEnumerable<SpatialRecord>> GetSpatialRecords { get; set; }

        public Func<int, IEnumerable<DeviceElementUse>> GetDeviceElementUses { get; set; }

        public string Description { get; set; }

    }
}
