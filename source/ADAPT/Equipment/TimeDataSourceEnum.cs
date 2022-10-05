/*******************************************************************************
  * Copyright (C) 2018 AgGateway and ADAPT Contributors
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors: Aaron Berger, transcription from PAIL; R. Andres Ferreyra, documentation.
  *    
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
     /// <summary>
     /// This enumeration provides a vocabulary for specifying the pedigree of timestamp data sources.
     /// This is important information; it can allow users of work records to better interpret the data.
     /// </summary>
    public enum TimeDataSourceEnum
    {
        /// <summary>
        /// The timestamp is created using GPS data, when the event happens. (Most accurate)
        /// </summary>
        GPSOnEvent,
        /// <summary>
        /// The timestamp is created using data from a realtime clock on the controller, panel, or device, when the event happens. 
        /// (Time intervals likely to be accurate; absolute times probably less so.)
        /// </summary>
        DeviceClockOnEvent,
        /// <summary>
        /// The timestamp is created using data from the server receiving the event data. 
        /// (May lead to inaccuracies if there are transmission delays.)
        /// </summary>
        ServerclockOnTransmission,
        /// <summary>
        /// The timestamp is created using data from a realtime clock on the controller, panel or device, when the event data is transmitted. 
        /// (May lead to inaccuracies if there are transmission delays, compounded with biases in the realtime clock time.)
        /// </summary>
        DeviceClockOnTransmission,
        /// <summary>
        /// The timestamp is input manually by an operator, asynchronously to the creation or transmission of the event.
        /// </summary>
        ManualInput,
        /// <summary>
        /// The origin of timestamp data is unknown.
        /// </summary>
        Unknown
    }
}