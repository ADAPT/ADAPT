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
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Guidance
{
    public class GuidanceShift
    {
        public int GuidanceGroupId { get; set; }

        public int GuidancePatterId { get; set; }

        public NumericRepresentationValue EastShift { get; set; }

        public NumericRepresentationValue NorthShift { get; set; }

        public NumericRepresentationValue PropagationOffset { get; set; }

        public List<int> TimeScopeIds { get; set; }
    }
}