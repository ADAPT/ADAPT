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
 *    Tarak Reddy - Moved WorkItems and WorkItemsOperations from Catalog
 *    Tarak Reddy - Mowed LoggedData and OperationData from LoggedDataCatalog
 *    Tarak Reddy - Moved GuidanceAllocations from Catalog
 *    Kathleen Oneal - added Summaries and LoggedDataCatalog
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace AgGateway.ADAPT.ApplicationDataModel.ADM
{
    public class Documents
    {
        public List<WorkItem> WorkItems { get; set; }

        public List<WorkItemOperation> WorkItemOperations { get; set; }

        public List<LoggedData.LoggedData> LoggedData { get; set; }

        public List<OperationData> OperationData { get; set; }

        public List<Plan> Plans { get; set; }

        public List<WorkOrder> WorkOrders { get; set; }

        public List<Recommendation> Recommendations { get; set; }

        public List<GuidanceAllocation> GuidanceAllocations { get; set; }

        public List<Summary> Summaries { get; set; }

        public int LoggedDataCatalog { get; set; }
    }
}
