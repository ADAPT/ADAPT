/*******************************************************************************
 * Copyright (C) 2016 AgGateway and ADAPT Contributors
 * Copyright (C) 2016 Deere and Company
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors:
 *    Justin Sliekers - implement device element changes, initial creation
 *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public abstract class DeviceElementConfiguration
    {
        public DeviceElementConfiguration()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            TimeScopes = new List<TimeScope>();
            Offsets = new List<NumericRepresentationValue>();
        }

        public CompoundIdentifier Id { get; private set; }

        public int DeviceElementId { get; set; }

        public string Description { get; set; }

        public List<TimeScope> TimeScopes { get; set; }

        public List<NumericRepresentationValue> Offsets { get; set; } 
    }
}
