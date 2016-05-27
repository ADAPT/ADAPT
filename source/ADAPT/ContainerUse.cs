/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Jospeh Ross - creating class
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class ContainerUse
    {
        public ContainerUse()
        {
            TimeScopes = new List<TimeScope>();
            DocumentIds = new List<int>();
        }

        public NumericRepresentationValue AmountUsed { get; set; }

        public int ContainerId { get; set; }

        public int ProductId { get; set; }

        public ContainerActionEnum ContainerAction { get; set; }

        public List<TimeScope> TimeScopes { get; set; }

        public List<int> DocumentIds { get; set; } 

    }
}
