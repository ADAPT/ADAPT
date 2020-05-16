/*******************************************************************************
  * Copyright (C) 2020 AgGateway and ADAPT Contributors
  * Copyright (C) 2020 Syngenta
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    R. Andres Ferreyra - initial implementation based on SPADE3, Traceability WG.
  *  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Products
{
    public class ContainerModel
    {

        public ContainerModel()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            ContextItems = new List<ContextItem>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public ContainerModelStatusEnum Status { get; set; }
        
        public NumericRepresentationValue Capacity { get; set; }

        public ContainerUseTypeEnum DefaultUseType { get; set; }

        public NumericRepresentationValue Length { get; set; }

        public NumericRepresentationValue Width { get; set; }

        public NumericRepresentationValue Height { get; set; }

        public List<ContextItem> ContextItems { get; set; } 

    }
}