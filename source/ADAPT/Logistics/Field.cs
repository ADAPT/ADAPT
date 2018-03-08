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
  *    Kathleen Oneal - added referenceLayerIds
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Logistics
{
    public class Field
    {
        public Field()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            ContextItems = new List<ContextItem>();
            GuidanceGroupIds = new List<int>();
            TimeScopes = new List<TimeScope>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public int? GrowerId { get; set; }

        public int? FarmId { get; set; }

        public NumericRepresentationValue Area { get; set; }

        public int? ActiveBoundaryId { get; set; }

        public List<ContextItem> ContextItems { get; set; }

        public NumericRepresentationValue Slope { get; set; }

        public NumericRepresentationValue Aspect { get; set; }

        public NumericRepresentationValue SlopeLength { get; set; }

        public List<int> GuidanceGroupIds { get; set; }

        public List<TimeScope> TimeScopes { get; set; }
    }
}