/*******************************************************************************
 * Copyright (C) 2018 AgGateway and ADAPT Contributors
 * Copyright (C) 2018 Ag Connections LLC
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors:
 *    R. Andres FerreyraJustin Sliekers - initial port from ADAPT data model
 *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Common;
using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class DeviceSeries
    {
        public DeviceSeries()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            ContextItems = new List<ContextItem>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public int BrandId { get; set; }

        public List<ContextItem> ContextItems { get; set; }
    }
}