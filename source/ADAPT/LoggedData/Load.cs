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
  *    Justin Sliekers - udpating DestinationId to collection and changed loadtype from EnumeratedRepresentation to LoadTypeEnum
  *******************************************************************************/


using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.LoggedData
{
    public class Load
    {
        public Load()
        {
            TimeScopeIds = new List<int>();
            DestinationIds = new List<int>();
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; set; }

        public string Description { get; set; }

        public List<int> TimeScopeIds { get; set; }

        public string LoadNumber { get; set; }

        public LoadTypeEnum LoadType { get; set; }

        public NumericRepresentationValue LoadQuality { get; set; }

        public List<int> DestinationIds { get; set; }
    }
}
