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
  *    Joseph Ross Making Properties
  *******************************************************************************/

using System;
using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class SpatialRecord
    {
        private readonly Dictionary<int, RepresentationValue> _meterValues = new Dictionary<int, RepresentationValue>(); 

        public Shape Geometry { get; set; }

        public DateTime Timestamp { get; set; }

        public void SetMeterValue(Meter meter, RepresentationValue value)
        {
            _meterValues.Add(meter.Id.ReferenceID, value);
        }

        public RepresentationValue GetMeterValue(Meter meter)
        {
            if (_meterValues.ContainsKey(meter.Id.ReferenceID))
                return _meterValues[meter.Id.ReferenceID];
            return null;
        }

        public int GetAppliedLatency { get; set; }
    }
}
