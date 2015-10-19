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

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class Guidance
    {
        public Guidance()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public GuidancePatternType GuidancePatternType { get; set; }

        public GpsSourceType GpsSource { get; set; }

        public string OriginalEpsgCode { get; set; }

        public string Name { get; set; }

        public double SwathWidth { get; set; }

        public PropagationDirectionEnum PropagationDirection { get; set; }

        public ExtensionEnum Extension { get; set; }

        public int? NumbersOfSwathsLeft { get; set; }

        public int NumbersOfSwathsRight { get; set; }

        public Polygon BoundingPolygon { get; set; }
    }
}
