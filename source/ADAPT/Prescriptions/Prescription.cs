/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Justin Sliekers - initial API and implementation
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class Prescription
    {
        public Prescription()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public OperationTypeEnum OperationType { get; set; }

        public int FieldId { get; set; }

        public int? CropZoneId { get; set; }

        public List<int> ProductIds { get; set; }

        public List<ContextItem> ContextItems { get; set; }
    }
}
