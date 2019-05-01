/*******************************************************************************
  * Copyright (C) 2015, 2018, 2019 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * Copyright (C) 2019 Syngenta  
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html>
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *    Justin Sliekers - udpating DefinedRepresentation to EnumeratedRepresentation
  *    Justin Sliekers - udpating DestinationId to collection and changed loadtype from EnumeratedRepresentation to LoadTypeEnum
  *    R. Andres Ferreyra - fixing typo: renaming LoadQuality to LoadQuantity. Adding QUALITY attributes (i.e, OMs) can wait to v2.1
  *    R. Andres Ferreyra - fixing bug: TimeScopes are used by value in ADAPT, not by reference. Changing accordingly.
  *    R. Andres Ferreyra - Adding list of ContextItems, to accommodate USDA-specific attributes for cotton.
  *    20190430 R. Andres Ferreyra - Adding reference to an Observations document.
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
            TimeScopes = new List<TimeScope>();
            DestinationIds = new List<int>();
            Id = CompoundIdentifierFactory.Instance.Create();
            ContextItems = new List<ContextItem>();
        }

        public CompoundIdentifier Id { get; set; }

        public string Description { get; set; }

        public List<TimeScope> TimeScopes { get; set; } // RAF 20181018: Changed this from a list of integer references.

        public string LoadNumber { get; set; }

        public LoadTypeEnum LoadType { get; set; }

        public NumericRepresentationValue LoadQuantity { get; set; }

        public List<int> DestinationIds { get; set; }
        
        public List<ContextItem> ContextItems { get; set; }
        
        public int? ObservationsId { get; set; } // 20190430 Added O&M support
    }
}
