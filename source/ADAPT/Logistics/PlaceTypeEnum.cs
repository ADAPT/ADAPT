/*******************************************************************************
  * Copyright (C) 2019 AgGateway, ADAPT Contributors
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  * 20190319: R. Andres Ferreyra created the class from PAIL and Traceability WG work.  
  *    
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Logistics
{
    public enum PlaceTypeEnum
    {
        Position, // This case produces a Place that is functionally equivalent to a PAIL Location. 
        LineString, // Enables PAIL's LineString feature-of-interest
        MultiPolygon, // Enables PAIL's MultiPolygon feature-of-interest
        Location,
        Facility,
        DeviceElement,
        Container, 
        Farm,
        Field,        
        CropZone,
        Mixed // Enables "adding what you know"; when there may be position, farm & field, for example.        
    }

}
