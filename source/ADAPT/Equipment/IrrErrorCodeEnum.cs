/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors: Aaron Berger, transcription from PAIL; R. Andres Ferreyra, documentation
  *    
  *    
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    /// <summary>
    /// This enumeration provides a simple, consensus vocabularyto  specify the type of error reported by an irrigation system.
    /// </summary>     
    public enum IrrErrorCodeEnum
    {
        Communication,
        LowPressure,
        Unspecified
    }
}
