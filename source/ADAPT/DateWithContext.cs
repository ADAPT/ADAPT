/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Kathleen Oneal - initial API and implementation
  *******************************************************************************/

using System;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class DateWithContext
    {
        public DateTime TimeStamp { get; set; }

        public DateContextEnum DateContext { get; set; }

        public Location Location { get; set; }
    }
}