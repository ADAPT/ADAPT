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
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public class DensityFactor
    {
        public DensityFactor()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            TimeScopeIds = new List<int>();
        }

        public CompoundIdentifier Id { get; set; }

        public int ProductId { get; set; }

        public string BatchNo { get; set; }

        public string LotNo { get; set; }

        public NumericRepresentationValue Density { get; set; }

        public List<int> TimeScopeIds { get; set; }
    }
}
