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
 *    Joseph Ross - Making Properties
 *    Tarak Reddy - Added MachineId
 *    Kathleen Oneal - changed TimeScope list of ints to single TimeScope
 *******************************************************************************/

using System;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class MachineConfiguration : MarshalByRefObject
    {
        public MachineConfiguration()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public TimeScope TimeScope { get; set; }
        
        public NumericRepresentationValue GpsReceiverXOffset { get; set; }
        
        public NumericRepresentationValue GpsReceiverYOffset { get; set; }
        
        public NumericRepresentationValue GpsReceiverZOffset { get; set; }
        
        public OriginAxleLocationEnum OriginAxleLocation { get; set; }
        
        public List<int> ConnectorIds { get; set; }
        
        public int MachineId { get; set; }
    }
}
