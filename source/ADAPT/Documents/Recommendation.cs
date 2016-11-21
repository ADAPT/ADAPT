/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Justin Sliekers - initial API and implementation
  *    Kathleen Oneal - added props cropSeasonId, WorkItems, Attachments
  *    Justin Sliekers - removing all properties
  *    Joseph Ross - adding workItemIds to match uml
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class Recommendation : Document
    {
        public Recommendation()
        {
            WorkItemIds = new List<int>();
        }

        public List<int> WorkItemIds { get; set; }
    }
}
