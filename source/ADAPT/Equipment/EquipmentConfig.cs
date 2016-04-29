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
  *    Kathleen Oneal - changed lists to ienumerables for effeciency  
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class EquipmentConfig
    {
        public EquipmentConfig()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public List<TimeScope> TimeScopes { get; set; }

        public int? MachineConfigurationId { get; set; }

        public int? ImplementConfigurationId { get; set; }

        public IEnumerable<Meter> Meters { get; set; }

        public IEnumerable<Section> Sections { get; set; }

        public IEnumerable<DataLogTrigger> Triggers { get; set; }
    }
}