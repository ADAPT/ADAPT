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
  *    Kathleen Oneal - changed ContextItemType to int
  *    Joseph Ross - Added TimeScopes to match uml
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    public class ContextItem
    {
        public int ContextItemType { get; set; }

        public RepresentationValue Value { get; set; }

        public List<ContextItem> ContextItems { get; set; }

        public List<TimeScope> TimeScopes { get; set; } 
    }
}