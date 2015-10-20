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
  *    Justin Sliekers - udpating DefinedRepresentation to EnumeratedRepresentation
  *******************************************************************************/


using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class Load
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public List<int> TimeScopeIds { get; set; }

        public string LoadNumber { get; set; }

        public EnumeratedRepresentation LoadType { get; set; }

        public NumericRepresentationValue LoadQuality { get; set; }

        public int DestinationId { get; set; }
    }
}
