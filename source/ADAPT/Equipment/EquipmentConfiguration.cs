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
  *    Kathleen Oneal - changed lists to ienumerables for effeciency
 *    Justin Sliekers - implement device element changes
 *    Joseph Ross - renamed class
 *    Joseph Ross - removed workItemOperationId and operationDataId Added Id and description
 *    Joseph Ross - made Connector2Id nullable
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class EquipmentConfiguration
    {
        public EquipmentConfiguration()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            DataLogTriggers = new List<DataLogTrigger>();
//            ContainerEquipmentAllocations = new List<ContainerEquipmentAllocation>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public int Connector1Id { get; set; }

        public int? Connector2Id { get; set; }

        public List<DataLogTrigger> DataLogTriggers { get; set; } 

//        public List<ContainerEquipmentAllocation> ContainerEquipmentAllocations { get; set; } 
    }
}