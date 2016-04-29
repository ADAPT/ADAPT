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
  *    Kathleen Oneal - changed LayerType to ReferenceLayerTypeEnum
  *    Justin Sliekers - changing BoundingPolygon to Polgyon; changing to single timescope
  *    Kathleen Oneal - added fieldIds and cropZoneIds
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers
{
    public abstract class ReferenceLayer
    {
        protected ReferenceLayer()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public ReferenceLayerTypeEnum LayerType { get; set; }

        public List<TimeScope> TimeScopes { get; set; }

        public Polygon BoundingPolygon { get; set; }

        public List<ContextItem> ContextItems { get; set; }

        public List<int> FieldIds { get; set; }

        public List<int> CropZoneIds { get; set; }
    }
}