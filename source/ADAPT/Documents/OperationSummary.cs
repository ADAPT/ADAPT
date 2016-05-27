/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Jospeh Ross - creating class
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class OperationSummary
    {
        public OperationTypeEnum OperationType { get; set; }

        public int ProductId { get; set; }

        public int WorkItemOperationId { get; set; }
        
        public List<StampedMeteredValues> Data { get; set; }

        public int EquipmentConfigId { get; set; }
    }
}
