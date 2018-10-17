/*******************************************************************************
  * Copyright (C) 2018 AgGateway and ADAPT Contributors
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors: Aaron Berger: transcribed from PAIL Part 1 schema. Andres Ferreyra: Added documentation.
  *    
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
     /// <summary>
     /// Telemetry systems are plagued with data-orphaning problems when stored system setup/configuration (meta)data get out of sync 
     /// with the transactional data. This class provides a vocabulary for describing the telemetry system's ability to keep
     /// data and metadata in sync. Its values can advise a user when formulating a data-polling strategy; e.g., if a system is keeping
     /// only the latest version of its setup & configuration data, the user will be well-served by downloading data frequently.
     /// </summary>
    public enum SetupDataPedigreeEnum
    {
        /// <summary>
        /// The system is only keeping the latest copy of setup/configuration data. 
        /// </summary>
        LatestOnly,
        /// <summary>
        /// The system is keeping multiple versions of setup/configuration data, and keeping them time-binned. 
        /// </summary>
        MatchedByTimeInterval,
        /// <summary>
        /// The strategy used by the system for tracking changes in system configuration is unknown. 
        /// </summary>
        Unknown
    }
}
