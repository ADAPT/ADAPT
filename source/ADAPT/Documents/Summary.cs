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
 *    Stuart Rhea - Added CompoundIdentifier Id to Summary per model
 *                  Added WorkRecordId per model
 *                  Added GrowerId to Summary per model
 *                  Added List<TimeScope> TimeScopes to Summary per model
 *                  Removed ContainerUserIds from Summary per model
 *                  Added List<int> GuidanceAllocationIds to Summary per model
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.Notes;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class Summary
    {
        public Summary()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            TimeScopes = new List<TimeScope>();
            PersonRoleIds = new List<int>();
            GuidanceAllocationIds = new List<int>();
            WorkItemIds = new List<int>();
            LoggedDataIds = new List<int>();
            Notes = new List<Note>();
            SummaryData = new List<StampedMeteredValues>();
            OperationSummaries = new List<OperationSummary>();
        }

        public CompoundIdentifier Id { get; private set; }

        public int WorkRecordId { get; set; }

        public int? GrowerId { get; set; }

        public int? FarmId { get; set; }

        public int? FieldId { get; set; }

        public int? CropZoneId { get; set; }

        public List<TimeScope> TimeScopes { get; set; }

        public List<int> PersonRoleIds { get; set; }

        public EquipmentConfigurationGroup EquipmentConfigurationGroup { get; set; }

        public List<int> GuidanceAllocationIds { get; set; }

        public List<int> WorkItemIds { get; set; }

        public List<int> LoggedDataIds { get; set; }

        public List<Note> Notes { get; set; }

        public List<StampedMeteredValues> SummaryData { get; set; }

        public List<OperationSummary> OperationSummaries { get; set; }

    }
}