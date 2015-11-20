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
  *    Kathleen Oneal - moved machineId and guidanceAllocationIds from workRecord to this
  *    Kathleen Oneal - changed OperationDataIds to WorkItemIds
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class LoggedData : WorkRecord
    {
        public List<int> WorkItemIds { get; set; } 

        public List<LoggedNote> LoggedNotes { get; set; } 

        public int? MachineId { get; set; }

        public List<int> GuidanceAllocationIds { get; set; }
    }
}