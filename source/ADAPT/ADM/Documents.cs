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
 *    Tim Shearouse - Added Loads
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace AgGateway.ADAPT.ApplicationDataModel.ADM
{
    public class Documents
    {
        public Documents()
        {
            WorkItems = new List<WorkItem>();
            WorkItemOperations = new List<WorkItemOperation>();
            LoggedData = new List<LoggedData.LoggedData>();
            Plans = new List<Plan>();
            WorkOrders = new List<WorkOrder>();
            Recommendations = new List<Recommendation>();
            GuidanceAllocations = new List<GuidanceAllocation>();
            Summaries = new List<Summary>();
            WorkRecords = new List<WorkRecord>();
            DeviceElementUses = new List<DeviceElementUse>();
            Loads = new List<Load>();
        }

        public IEnumerable<WorkItem> WorkItems { get; set; }

        public IEnumerable<WorkItemOperation> WorkItemOperations { get; set; }
               
        public IEnumerable<LoggedData.LoggedData> LoggedData { get; set; }
               
        public IEnumerable<Plan> Plans { get; set; }
               
        public IEnumerable<WorkOrder> WorkOrders { get; set; }

        public IEnumerable<WorkRecord> WorkRecords { get; set; }
               
        public IEnumerable<Recommendation> Recommendations { get; set; }
               
        public IEnumerable<GuidanceAllocation> GuidanceAllocations { get; set; }
               
        public IEnumerable<Summary> Summaries { get; set; }

        public int LoggedDataCatalog { get; set; }

        public IEnumerable<DeviceElementUse> DeviceElementUses { get; set; }

        public IEnumerable<Load> Loads { get; set; }
    }
}
