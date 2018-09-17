/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Jospeh Ross - creating class
  *    Kelly Nelson - added reference to DeviceElementConfiguration
  *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class MeteredValue
    {
        public RepresentationValue Value { get; set; }

        public int? MeterId { get; set; }

        public int? DeviceConfigurationId { get; set; }
    }
}
