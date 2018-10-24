/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Jospeh Ross - creating class
  *	   Stuart Rhea - Added ContextItems per model.
  *	   Jason Roesbeke - added Description
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class OperationSummary
    {
        public OperationSummary()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            EquipmentConfigurationIds = new List<int>();
            ContextItems = new List<ContextItem>();
        }

        public CompoundIdentifier Id { get; private set; }

        public OperationTypeEnum OperationType { get; set; }

        public int ProductId { get; set; }

        public int? WorkItemOperationId { get; set; }
        
        public List<StampedMeteredValues> Data { get; set; }

        public List<int> EquipmentConfigurationIds { get; set; }

        public MultiPolygon CoverageShape { get; set; }

        public List<ContextItem> ContextItems { get; set; }

        public string Description { get; set; }

    }
}
