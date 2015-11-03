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
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class Container
    {
        public Container()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public NumericRepresentationValue ProductAmount { get; set; }
        
        public NumericRepresentationValue Capacity { get; set; }

        public List<ContextItem>  ContextItems { get; set; }

        public string Description { get; set; }

        public CompoundIdentifier Id { get; private set; }
    }
}
