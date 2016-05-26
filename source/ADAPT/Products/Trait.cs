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
  *    Kathleen Oneal - Added Properties
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public class Trait
    {
        public Trait()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            CropIds = new List<int>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string TraitCode { get; set; }

        public string Description { get; set; }

        public int? ManufacturerId { get; set; }

        public List<int> CropIds { get; set; }
    }
}
