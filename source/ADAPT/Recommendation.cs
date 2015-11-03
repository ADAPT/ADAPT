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
  *******************************************************************************/

using System.Collections.Generic;
using System.Net.Mail;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class Recommendation : Document
    {
        public int CropSeasonId { get; set; }

        public List<WorkItem> WorkItems { get; set; }

        public List<Attachment> Attachments { get; set; }
    }
}
