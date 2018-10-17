/*******************************************************************************
  * Copyright (C) 2015-16, 2018 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *    Tarak Reddy - Updated List of GuidanceId to List GuidanceAllocationId
  *    Kathleen Oneal - removed all properties
  *    Joseph Ross - Added LoggedDataIds and SummaryIds
  *    R. Andres Ferreyra - Added IrrRecordIds to accommodate PAIL work records
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class WorkRecord : Document
    {
        public WorkRecord()
        {
            LoggedDataIds = new List<int>();
            SummariesIds = new List<int>();
            IrrRecordIds = new List<int>();            
        }

        public List<int> LoggedDataIds { get; set; }
        public List<int> SummariesIds { get; set; }
        public List<int> IrrRecordIds { get; set; }
    }
}