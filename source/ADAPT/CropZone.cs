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
  *******************************************************************************/  

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class CropZone
    {
        public CropZone()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public List<int> TimeScopeIds { get; set; }
        public string Description { get; set; }
        public int FieldId { get; set; }
        public int? CropId { get; set; }
        public NumericRepresentationValue Area { get; set; }
        public MultiPolygon BoundingRegion { get; set; }
        public GpsSourceEnum BoundarySource { get; set; }
        public List<int> NoteIds { get; set; }
        public List<int> GuidanceGroupIds { get; set; }
        public List<ContextItem> ContextItems { get; set; } 
    }
}
