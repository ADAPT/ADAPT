/*******************************************************************************
  * Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2016 Ag Connections
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Stuart Rhea - initial API and implementation
  *    Joseph Ross - updated format
  *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    /// <summary>
    /// This object is used by value inside ContextItem.Properties, ContextItemDefinition.Properties, or ContextItemEnumItem.Properties.
    /// It is also available to be used on any ADAPT class containing a ContextItem list.
    /// </summary>
    public class ContextItem
    {
        public ContextItem()
        {
            NestedItems = new List<ContextItem>();
            TimeScopes = new List<TimeScope>();
        }

        /// <summary>
        /// Code property. </summary>
        /// <value>
        /// Always refers to ContextItemDefinition.Code. This value is required.</value>
        public string Code { get; set; }

        /// <summary>
        /// Value property. </summary>
        /// <value>
        /// The value (represented as a string) associated with the target ContextItemDefinition. This value is optional.</value>
        public string Value { get; set; }

        /// <summary>
        /// ValueUOM property. </summary>
        /// <value>
        /// The unit of measure associated with the indicated value. This value is optional.</value>
        public string ValueUOM { get; set; }

        /// <summary>
        /// Properties list property. </summary>
        /// <value>
        /// This list contains the nested ContextItem data that repesents the use of a "nested" ContextItemDefinition (ContextItem values for the ContextItemDefinitions included in ContextItemDefinition.NestedItemIds). This value is optional.</value>
        public List<ContextItem> NestedItems { get; set; }

        /// <summary>
        /// TimeScopes list property. </summary>
        /// <value>
        /// List of TimeScope that communicate the time attributes of the indicated value. This value is optional.</value>
        public List<TimeScope> TimeScopes { get; set; }
    }
}