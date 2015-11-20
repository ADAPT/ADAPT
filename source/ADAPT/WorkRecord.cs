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
  *    Tarak Reddy - Updated List of GuidanceId to List GuidanceAllocationId
  *    Kathleen Oneal - removed all properties
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class WorkRecord : Document
    {
        public int? FarmId { get; set; }
        public int? FieldId { get; set; }
        public int? SeasonId { get; set; }
        public int? WorkItemId { get; set; }
        public List<int> ContextItemIds { get; set; }
        public int? CropZoneId { get; set; }
        public int? PersonRoleId { get; set; }
        public List<int> WorkItemIds { get; set; }
        public List<StatusUpdate> StatusUpdates { get; set; }
    }
}