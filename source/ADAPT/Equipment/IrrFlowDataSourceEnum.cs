/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors: Aaron Berger, transcribe from PAIL; R. Andres Ferreyra: Documentation
  *    
  *    
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    /// <summary>
    /// Provides a vocabulary for where flow data comes from. 
    /// </summary>
    public enum IrrFlowDataSourceEnum
    {
        /// <summary>
        /// Flow data is being reported by a flow meter 
        /// </summary>
        FlowMeter,
        /// <summary>
        /// Flow data estimated by multiplying time by a constant 
        /// </summary>
        HourMeter,
        /// <summary>
        /// Flow data not reported, or source unknown
        /// </summary>
        Unknown
    }
}
