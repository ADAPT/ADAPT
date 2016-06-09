/*******************************************************************************
  * Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2016 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Joseph Ross - Intial commit
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class EquipmentConfigurationGroup
    {
        public EquipmentConfigurationGroup()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            EquipmentConfigurations = new List<EquipmentConfiguration>();
            TimeScopes = new List<TimeScope>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public List<EquipmentConfiguration> EquipmentConfigurations { get; set; }
 
        public List<TimeScope> TimeScopes { get; set; }
    }
}
