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
    public class RadialExtent
    {
        public RadialExtent()
        {
            
        }
        
        public NumericRepresentationValue StartAngle { get; set; }

        public NumericRepresentationValue EndAngle { get; set; }

        public int? SectionId { get; set; }

        public NumericRepresentationValue InnerRadius { get; set; }

        public NumericRepresentationValue OuterRadius { get; set; }

        public Point RotCtr { get; set; }

    }
}
