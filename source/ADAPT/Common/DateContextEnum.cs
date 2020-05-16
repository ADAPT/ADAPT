/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * Copyright (C) 2019 Syngenta
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *    Kathleen Oneal - added additional values
  *    R. Andres Ferreyra - added PAIL / OM-related values, and comments.
  *******************************************************************************/  

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    public enum DateContextEnum
    {
        Approval,
        ProposedStart,
        ProposedEnd,
        CropSeason,  // Interval
        TimingEvent, // Interval
        ActualStart,
        ActualEnd,
        RequestedStart,
        RequestedEnd,
        Expiration,  // Relevant for Plans, Work Orders, and Recommendations
        Creation,  // Relevant to any document or object instance
        Modification,  // Relevant to any document or object instance
        ValidityRange, // Interval. Used for Recommendation documents, also for specialized ISO 19156 Observations (such as forecasts)
        RequestedShipping,
        ActualShipping,
        Calibration,  // Relevant to a DeviceElement (esp. Sensor)
        Load,
        Unload,
        Suspend,
        Resume,
        Unspecified,
        Installation, // When was the device, sensor, etc. installed?
        Maintenance, // When was maintenance performed on the device, sensor, etc.?
        PhenomenonTime, // Important attribute of an ISO 19156 Observation
        ResultTime // Interval. Important attribute of an ISO 19156 Observation
    }
}
