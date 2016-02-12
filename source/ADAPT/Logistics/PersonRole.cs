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
  *    Kathleen Oneal - changed Role from string to PersonRolesEnum
  *    Justin Sliekers - changed EmployerId to CompanyId, changed to list of Timescope for ActiveScopes
  *******************************************************************************/

using System;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Logistics
{
    public class PersonRole : MarshalByRefObject
    {
        public PersonRole()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public int PersonId { get; set; }

        public PersonRolesEnum Role { get; set; }
        
        public int? GrowerId { get; set; }

        public List<TimeScope> ActiveScopes { get; set; }

        public int? CompanyId { get; set; }
    }
}
