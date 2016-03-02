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
  *    Joseph Ross Making Properties
 *    Kathleen Oneal - changed meters to GetMeters
  *******************************************************************************/

using System;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.LoggedData
{
    public class Section
    {
        public Section()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public int OperationDataId { get; set; }

        public int Depth { get; set; }

        public int Order { get; set; }

        public NumericRepresentationValue SectionWidth { get; set; }

        public NumericRepresentationValue TotalDistanceTravelled { get; set; }

        public NumericRepresentationValue TotalElapsedTime { get; set; }

        public Func<IEnumerable<Meter>> GetMeters { get; set; }
    }
}
