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
  *    Kathleen Oneal - added parameters to GetAppliedLatency
  *******************************************************************************/

using System;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.LoggedData
{
    public class SpatialRecord : MarshalByRefObject
    {
        private readonly Dictionary<int, RepresentationValue> _meterValues = new Dictionary<int, RepresentationValue>(); 
        private readonly Dictionary<int, int?> _appliedLatencyValues = new Dictionary<int, int?>(); 

        public Shape Geometry { get; set; }

        public DateTime Timestamp { get; set; }

        public void SetMeterValue(Meter meter, RepresentationValue value)
        {
            _meterValues.Add(meter.Id.ReferenceId, value);
        }

        public RepresentationValue GetMeterValue(Meter meter)
        {
            if (_meterValues.ContainsKey(meter.Id.ReferenceId))
                return _meterValues[meter.Id.ReferenceId];
            return null;
        }

        public void SetAppliedLatency(Meter meter, int? latencyValue)
        {
            _appliedLatencyValues.Add(meter.Id.ReferenceId, latencyValue);
        }

        public int? GetAppliedLatency(Meter meter)
        {
            if (_appliedLatencyValues.ContainsKey(meter.Id.ReferenceId))
                return _appliedLatencyValues[meter.Id.ReferenceId];
            return null;
        }
    }
}
