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
  *    Jason Roesbeke - Added a list with TimeScopes and a list with Personroles
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;

namespace AgGateway.ADAPT.ApplicationDataModel.Prescriptions
{
    public class Prescription
    {
        public Prescription()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            RxProductLookups = new List<RxProductLookup>();
            ProductIds = new List<int>();
            ContextItems = new List<ContextItem>();
            TimeScopes = new List<TimeScope>();
            PersonRoles = new List<PersonRole>();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public OperationTypeEnum OperationType { get; set; }

        public int FieldId { get; set; }

        public int? CropZoneId { get; set; }

        public List<RxProductLookup> RxProductLookups { get; set; }

        public List<int> ProductIds { get; set; }

        public List<ContextItem> ContextItems { get; set; }

        public List<TimeScope> TimeScopes { get; set; }

        public List<PersonRole> PersonRoles { get; set; }

    }
}
