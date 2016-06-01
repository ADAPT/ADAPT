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
  *    Kathleen Oneal - changed lists to ienumerables for effeciency
 *    Justin Sliekers - implement device element changes
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class EquipmentConfig
    {
        public EquipmentConfig()
        {
            DataLogTriggers = new List<DataLogTrigger>();
            ContainerEquipmentAllocations = new List<ContainerEquipmentAllocation>();
        }

        public int Connector1Id { get; set; }

        public int Connector2Id { get; set; }

        public List<DataLogTrigger> DataLogTriggers { get; set; } 

        public List<ContainerEquipmentAllocation> ContainerEquipmentAllocations { get; set; } 

        public int? WorkItemOperationId { get; set; }

        public int? OperationDataId { get; set; }
    }
}