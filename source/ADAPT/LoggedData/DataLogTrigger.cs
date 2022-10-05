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
  *    Stuart Rhea - #96 Remove SectionId from DataLogTrigger
  *                  #97 Replace DataLogTrigger.MeterId with DataLogTrigger.DeviceElementId
  *    Kelly Nelson - Change DataLogMethod to DataLogMethods and add RequestDefaultProcessData
  *******************************************************************************/

using System;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.LoggedData
{
    public class DataLogTrigger
    {
        public DataLogTrigger()
        {
            Id = CompoundIdentifierFactory.Instance.Create();

            ContextItems = new List<ContextItem>();
            DataLogMethods = new List<LoggingMethodEnum>();
        }

        public CompoundIdentifier Id { get; private set; }

        [Obsolete("Prefer DataLogMethods to capture multiple methods")]
        public LoggingMethodEnum DataLogMethod { get; set; }

        public List<LoggingMethodEnum> DataLogMethods { get; set; }

        public NumericRepresentationValue DataLogDistanceInterval { get; set; }

        public NumericRepresentationValue DataLogTimeInterval { get; set; }

        public NumericRepresentationValue DataLogThresholdMinimum { get; set; }

        public NumericRepresentationValue DataLogThresholdMaximum { get; set; }

        public NumericRepresentationValue DataLogThresholdChange { get; set; }

        public List<ContextItem> ContextItems { get; set; }

        public LoggingLevelEnum LoggingLevel { get; set; }

        public Representation Representation { get; set; }

        /// <summary>
        /// A special DataLogTrigger that indicates that the task controller should log its default set of data
        /// If this is true, Representation should not be set.
        /// </summary>
        public bool RequestDefaultProcessData { get; set; }

        public int? DeviceElementId { get; set; } 
    }
}
