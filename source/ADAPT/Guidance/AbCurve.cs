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
  *    Kelly Nelson - Setting type in default constructor
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Guidance
{
    public class AbCurve : GuidancePattern
    {
        public AbCurve()
        {
            Shape = new List<LineString>();
            GuidancePatternType = GuidancePatternTypeEnum.AbCurve;
        }

        public int NumberOfSegments { get; set; }

        public double? Heading { get; set; }

        public double? EastShiftComponent { get; set; }

        public double? NorthShiftComponent { get; set; }

        public List<LineString> Shape { get; set; }
    }
}
