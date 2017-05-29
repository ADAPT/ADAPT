/*******************************************************************************
  * Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *    Justin Sliekers - udpating DefinedRepresentation to EnumeratedRepresentation
  *    Joseph Ross Making Properties
 *    Kathleen Oneal - changed connectorType to ConnectoryTypeEnum from EnumeratedRepresentation
 *    Justin Sliekers - implement device element changes
 *    Stuart Rhea - #95 Rename Connector.DeviceConfigurationId to Connector.DeviceElementConfigurationId
  *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class Connector
    {
        public Connector()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public int DeviceElementConfigurationId { get; set; }

        public int HitchPointId { get; set; }
    }
} 
