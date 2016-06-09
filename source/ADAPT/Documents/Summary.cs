/*******************************************************************************
 * Copyright (C) 2015-16 AgGateway and ADAPT Contributors
 * Copyright (C) 2015-16 Deere and Company
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors:
 *    Kathleen Oneal - initial API and implementation
 *    Kathleen Oneal - added properties, growerId, FarmIds, FieldIds, CropZoneIds
 *    Joseph Ross - updated to match uml
 *    Joseph Ross - added EquipmentConfigurationGroup
 *    Joseph Ross - inherits document
 *    Joseph Ross - removed Document Inheretance added properties
 *    Joseph Ross - renaming person roles
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.Notes;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class Summary
    {
        public Summary()
        {
            PersonRoleIds = new List<int>();
            Notes = new List<Note>();
            SummaryData = new List<StampedMeteredValues>();
            LoggedDataIds = new List<int>();
            WorkItemIds = new List<int>();
            OperationSummaries = new List<OperationSummary>();
            ContainerUseIds = new List<int>();
        }

        public List<StampedMeteredValues> SummaryData { get; set; }

        public int? FarmId { get; set; }

        public int? FieldId { get; set; }

        public int? CropZoneId { get; set; }

        public List<int> PersonRoleIds { get; set; }
        
        public List<Note> Notes { get; set; } 

        public List<int> LoggedDataIds { get; set; }

        public List<int> WorkItemIds { get; set; } 

        public List<OperationSummary> OperationSummaries { get; set; }

        public List<int> ContainerUseIds { get; set; }

        public EquipmentConfigurationGroup EquipmentConfigurationGroup { get; set; }
    }
}