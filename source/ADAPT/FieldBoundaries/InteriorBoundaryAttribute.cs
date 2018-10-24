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
  *    Joseph Ross Making Properties
  *    Kathleen Oneal - changed Passable to IsPassable and Name to Description
  *    Kelly Nelson  - changed ShapeIdRef to Shape
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries
{
    public class InteriorBoundaryAttribute
    {
        public Shapes.Shape Shape { get; set; }

        public bool IsPassable { get; set; }

        public string Description { get; set; }
    }
}
