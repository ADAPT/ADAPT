/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors: Aaron Berger, transcribe from PAIL; R. ANdres Ferreyra, documentation
  *    
  *    
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    /// <summary>
    /// This enumeration provides a simple vocabulary to specify the location within the irrigation system where pressure is being measured.
    /// This is important because corrections for height/head may be necessary in order to compare pressures measured at
    /// different locations. 
    /// </summary>  
    public enum IrrPressureLocationEnum
    {
        AtPump,
        AtBaseOfSystem,
        AtEndOfSystem,
        Unknown
    }
}
