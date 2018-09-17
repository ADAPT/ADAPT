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
  *    Stuart Rhea - #116 Rename CenterPivot to PivotGuidancePattern
  *    Kelly Nelson - #167 Allow for multiple definition methods
  *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Guidance
{
    public class PivotGuidancePattern : GuidancePattern
    {
        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }

        public Point Center { get; set; }

        public NumericRepresentationValue Radius { get; set; }

        public Point Point1 { get; set; }

        public Point Point2 { get; set; }

        public Point Point3 { get; set; }

        public PivotGuidanceDefinitionEnum DefinitionMethod { get; set; }
    }
}
