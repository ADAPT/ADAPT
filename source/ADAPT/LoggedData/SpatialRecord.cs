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
    public class SpatialRecord
    {
        private readonly Dictionary<int, RepresentationValue> _meterValues; 
        private readonly Dictionary<int, int?> _appliedLatencyValues;

        public SpatialRecord()
        {
            _meterValues = new Dictionary<Int32, RepresentationValue>();
            _appliedLatencyValues = new Dictionary<Int32,Int32?>();
        }

        // This overload offers a small performance improvement by avoiding dictionary resizing when calling SetMeterValue.
        public SpatialRecord(int numberOfMeters)
        {
            _meterValues = new Dictionary<Int32,RepresentationValue>(numberOfMeters);
            _appliedLatencyValues = new Dictionary<Int32,Int32?>();
        }

        public Shape Geometry { get; set; }

        public DateTime Timestamp { get; set; }

        public void SetMeterValue(WorkingData workingData, RepresentationValue value)
        {
            _meterValues.Add(workingData.Id.ReferenceId, value);
        }

        public RepresentationValue GetMeterValue(WorkingData workingData)
        {
            if (_meterValues.ContainsKey(workingData.Id.ReferenceId))
                return _meterValues[workingData.Id.ReferenceId];
            return null;
        }

        public void SetAppliedLatency(WorkingData workingData, int? latencyValue)
        {
            _appliedLatencyValues.Add(workingData.Id.ReferenceId, latencyValue);
        }

        public int? GetAppliedLatency(WorkingData workingData)
        {
            if (_appliedLatencyValues.ContainsKey(workingData.Id.ReferenceId))
                return _appliedLatencyValues[workingData.Id.ReferenceId];
            return null;
        }
    }
}
