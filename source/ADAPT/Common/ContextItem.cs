/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Ag Connections
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Stuart Rhea - initial API and implementation
  *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    /// <summary>
    /// This object is used by value inside ContextItem.Properties, ContextItemDefinition.Properties, or ContextItemEnumItem.Properties.
    /// It is also available to be used on any ADAPT class containing a ContextItem list.
    /// </summary>
    public class ContextItem
    {
        /// <summary>
        /// Store for the Code property.</summary>
        private string _code = null;
        /// <summary>
        /// Store for the Value property.</summary>
        private string _value = null;
        /// <summary>
        /// Store for the ValueUOM property.</summary>
        private string _valueUOM = null;
        /// <summary>
        /// Store for the Properties list property.</summary>
        private List<ContextItem> _nestedItems;
        /// <summary>
        /// Store for the TimeScopes list property.</summary>
        private List<TimeScope> _timeScopes;

        public ContextItem()
        {
            _nestedItems = new List<ContextItem>();
            _timeScopes = new List<TimeScope>();
        }

        /// <summary>
        /// Code property. </summary>
        /// <value>
        /// Always refers to ContextItemDefinition.Code. This value is required.</value>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        /// Value property. </summary>
        /// <value>
        /// The value (represented as a string) associated with the target ContextItemDefinition. This value is optional.</value>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// ValueUOM property. </summary>
        /// <value>
        /// The unit of measure associated with the indicated value. This value is optional.</value>
        public string ValueUOM
        {
            get { return _valueUOM; }
            set { _valueUOM = value; }
        }

        /// <summary>
        /// Properties list property. </summary>
        /// <value>
        /// This list contains the nested ContextItem data that repesents the use of a "nested" ContextItemDefinition (ContextItem values for the ContextItemDefinitions included in ContextItemDefinition.NestedItemIds). This value is optional.</value>
        public List<ContextItem> NestedItems
        {
            get { return _nestedItems; }
            set { _nestedItems = value; }
        }

        /// <summary>
        /// TimeScopes list property. </summary>
        /// <value>
        /// List of TimeScope that communicate the time attributes of the indicated value. This value is optional.</value>
        public List<TimeScope> TimeScopes
        {
            get { return _timeScopes; }
            set { _timeScopes = value; }
        }

    }
}