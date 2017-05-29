﻿/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *    Joseph Ross Making Properties
  *    Kathleen Oneal - Added TriggerId
  *    Kathleen Oneal - removed property Values
 *    Justin Sliekers - implement device element changes
 *    Stuart Rhea - #98 Remove WorkingData.TriggerId
  *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.LoggedData
{
    public abstract class WorkingData
    {
        protected WorkingData()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public int DeviceElementUseId { get; set; }
        
        public Representation Representation { get; set; }
        
        public NumericRepresentationValue AppliedLatency { get; set; }

        public NumericRepresentationValue ReportedLatency { get; set; }

    }
}
