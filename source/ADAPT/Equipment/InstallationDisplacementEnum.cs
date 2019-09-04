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
    public enum InstallationDisplacementEnum // Specifies the reference height from which sensor (or logger) vertical displacement is measured
    {
        MeanSeaLevel,  // Height / depth is specified relative to mean seal level
        SoilSurface,   // Height / depth is specified relative to the soil surface
        CropCanopyTop, // Height / depth is specified relative to the top of the crop canopy
        Logger         // Height / depth is specified relative to the position of the data logger
    }

}
