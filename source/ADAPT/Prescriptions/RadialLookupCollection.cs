/*******************************************************************************
  * Copyright (C) 2015, 2018 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    
  *    
  *******************************************************************************/
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Prescriptions
{
    public class RadialLookupCollection
    {
        public RadialLookupCollection()
        {
            RadialLookups = new List<RxRadialLookup>();
            ShapeLookups = new List<RxShapeLookup>();
        }
        public List<RxRadialLookup> RadialLookups { get; set; }

        public NumericRepresentationValue StartAngle { get; set; }

        public NumericRepresentationValue EndAngle { get; set; }

        public Point RotCtr { get; set; }

        public List<RxShapeLookup> ShapeLookups { get; set; }
    }
}
