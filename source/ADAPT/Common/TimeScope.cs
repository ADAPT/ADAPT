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
  *    Kathleen Oneal - removed StartLocation, EndLocation, and DateContext
  *    Kathleen Oneal - changed date params to Stamp1, Stamp2 of type DateWithContext
  *******************************************************************************/

using System;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    public class TimeScope
    {
        public TimeScope()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Description { get; set; }

        public DateContextEnum DateContext { get; set; }

        public DateTime? TimeStamp1 { get; set; }

        public DateTime? TimeStamp2 { get; set; }

        public Location Location1 { get; set; }

        public Location Location2 { get; set; }

        public TimeSpan? Duration { get; set; }

        public Representation Representation { get; set; }
    }
}
