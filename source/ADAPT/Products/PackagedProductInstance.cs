/*******************************************************************************
  * Copyright (C) 2020 AgGateway and ADAPT Contributors
  * Copyright (C) 2020 Syngenta
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    R. Andres Ferreyra - initial implementation
  *  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public class PackagedProductInstance
    {

        public PackagedProductInstance()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            ContainedPackagedProductInstanceIds = new List<int>();
            ContextItems = new List<ContextItem>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public int PackagedProductId { get; set; }

        public NumericRepresentationValue ProductQuantity { get; set; }

        public List<int> ContainedPackagedProductInstanceIds { get; set; }

        public NumericRepresentationValue Height { get; set; }

        public NumericRepresentationValue GrossWeight { get; set; }

        public NumericRepresentationValue NetWeight { get; set; }

        public int? ContainerId { get; set; } 

        public List<ContextItem> ContextItems { get; set; } 

    }
}