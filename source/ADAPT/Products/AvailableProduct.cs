/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Kathleen Oneal - initial API and implementation
  *    Stuart Rhea - #113 Add list of TimeScopes to AvailableProduct
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public class AvailableProduct
    {
        public AvailableProduct()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            ContextItems = new List<ContextItem>();
            TimeScopes = new List<TimeScope>();
        }

        public CompoundIdentifier Id { get; private set; }

        public int ProductId { get; set; }

        public int GrowerId { get; set; }

        public List<ContextItem> ContextItems { get; set; }

        public List<TimeScope> TimeScopes { get; set; }
    }
}
