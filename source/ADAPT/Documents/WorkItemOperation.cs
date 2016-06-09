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
 *    Tarak Reddy - Added equipment config id to point to right machine configuration and implement configuration
 *    Justin Sliekers - implement device element changes
  *    Joseph Ross - Added EquipmentConfigurationIds
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class WorkItemOperation
    {
        public WorkItemOperation()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            EquipmentConfigurationIds = new List<int>();
        }

        public string Description { get; set; }
        
        public CompoundIdentifier Id { get; private set; }
        
        public OperationTypeEnum OperationType { get; set; }
        
        public int? PrescriptionId { get; set; }

        public List<int> EquipmentConfigurationIds { get; set; } 
    }
}
