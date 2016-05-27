/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Justin Sliekers - creating class
  *    Kathleen Oneal - changed ProductAmount & Capacity from type NumericRepresentation to NumericRepresentationValue
  *    Joseph Ross - removed ProductAmount & Capacity from type NumericRepresentation to NumericRepresentationValue and added ContainerType and Type Use to match uml
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class Container
    {
        public Container()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            ContextItems = new List<ContextItem>();
        }

        public List<ContextItem>  ContextItems { get; set; }

        public string Description { get; set; }

        public CompoundIdentifier Id { get; private set; }

        public EnumeratedValue ContainerUseType { get; set; }

        public int ContainerType { get; set; }
    }
}
