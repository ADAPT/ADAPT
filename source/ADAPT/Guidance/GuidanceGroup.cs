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
 *    Tarak Reddy - Renamed GuidanceId to GuidancePatternId
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Guidance
{
    public class GuidanceGroup
    {
        public GuidanceGroup()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            GuidancePatternIds = new List<int>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public List<int> GuidancePatternIds { get; set; }

        public MultiPolygon BoundingPolygon { get; set; }
    }
}
