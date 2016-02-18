/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Justin Sliekers - initial API and implementation
  *******************************************************************************/

using System;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Logistics
{
    public class GpsSource
    {
        public GpsSourceEnum SourceType { get; set; }

        public NumericRepresentationValue EstimatedPrecision { get; set; }

        public NumericRepresentationValue HorizontalAccuracy { get; set; }

        public NumericRepresentationValue VerticalAccuracy { get; set; }

        public int NumberOfSatellites { get; set; }

        public DateTime GpsUtcTime { get; set; }
    }
}
