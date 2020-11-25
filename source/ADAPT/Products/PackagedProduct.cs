/*******************************************************************************
  * Copyright (C) 2020 AgGateway and ADAPT Contributors
  * Copyright (C) 2020 Syngenta
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    R. Andres Ferreyra - initial implementation based on ProductStatusEnum class.
  *    R. Andres Ferreyra - added IsBulk attribute 8/18/20.
  *  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public class PackagedProduct
    {

        public PackagedProduct()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            ContainedPackagedProducts = new List<ContainedPackagedProduct>();
            ContextItems = new List<ContextItem>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        public int ContainerModelId { get; set; }

        public bool IsBulk { get; set; }

        public PackagedProductStatusEnum Status { get; set; }
        
        public NumericRepresentationValue ProductQuantity { get; set; }

        public List<ContainedPackagedProduct> ContainedPackagedProducts { get; set; }

        public NumericRepresentationValue GrossWeight { get; set; }

        public NumericRepresentationValue NetWeight { get; set; }

        public List<ContextItem> ContextItems { get; set; } 

    }
}