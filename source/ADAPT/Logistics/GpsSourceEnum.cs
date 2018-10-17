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
  *    Jason Roesbeke - Added PPP & SBAS
  *    R. ANdres Ferreyra - Added mechanical
  *******************************************************************************/  

namespace AgGateway.ADAPT.ApplicationDataModel.Logistics
{
    public enum GpsSourceEnum
    {
        Unknown,
        Drawn,
        MobileGPS,
        DeereRTK,
        DeereRTKX,
        DeereSF1,
        DeereSF2,
        DeereWAAS,
        GNSSfix,
        DGNSSfix,
        PreciseGNSS,
        RTKFixedInteger,
        RTKFloat,
        EstDRmode,
        ManualInput,
        SimulateMode,
        DesktopGeneratedData,
        Other,
        PPP, //Precise Point Positioning
        SBAS, //Satellite Based Augmentation System
        Mechanical // Represents mechanical and optical angle encoding mechanisms used primarily in center pivot irrigation systems.
    }
}
