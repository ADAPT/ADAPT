/*******************************************************************************
  * Copyright (C) 2015 AgGateway, ADAPT Contributors, and Syngenta
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  * 4/16/2019 R. Andres Ferreyra created the class transcribing from the X632-2 Observations schema.   
  *    
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public enum TelemetryMediumEnum // Specifies the type of telemetry used by a device to send/receive data.
    {
        Radio,         // The device uses a radio transmitter to send/receive data. 
        Satellite,     // The device uses a satellite system to send/receive data. 
        Hardwired,     // The device uses a physical connection (e.g., current loop, I2C, etc.) to send/receive data. 
        CellularRadio, // The device uses cellular telephony to send/receive data.
        Other          // The device uses an option not described above to send/receive data.
                       // Do not use "Other" to replace "unknown"; if the telemetry medium is unknown, leave the corresponding data field empty.
    }

}
