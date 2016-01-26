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
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class DataLogTrigger
    {
        public DataLogTrigger()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public LoggingMethodEnum DataLogMethod { get; set; }

        public NumericRepresentationValue DataLogDistanceInterval { get; set; }

        public NumericRepresentationValue DataLogTimeInterval { get; set; }

        public NumericRepresentationValue DataLogThresholdMinimum { get; set; }

        public NumericRepresentationValue DataLogThresholdMaximum { get; set; }

        public NumericRepresentationValue DataLogThresholdChange { get; set; }

        public List<ContextItem> ContextItems { get; set; }

        public LoggingLevelEnum LoggingLevel { get; set; }

        public Representation Representation { get; set; }

        public List<int> SectionIds { get; set; }

        public List<int> MeterIds { get; set; } 
    }
}