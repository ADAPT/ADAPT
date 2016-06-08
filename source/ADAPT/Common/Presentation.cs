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
    /// This object is used by value inside ContextItemDefinition.Presentations.
    /// </summary>
    public class Presentation
    {
        /// <summary>
        /// Store for the Description property.</summary>
        private string _description = null;
        /// <summary>
        /// Store for the EntryFormatRegEx property.</summary>
        private string _entryFormatRegEx = null;
        /// <summary>
        /// Store for the DisplayFormatRegEx property.</summary>
        private string _displayFormatRegEx = null;
        /// <summary>
        /// Store for the GeoPoliticalContextIds list property.</summary>
        private List<int> _geopoliticalContextIds;

        public Presentation()
        {
            _geopoliticalContextIds = new List<int>();
        }

        /// <summary>
        /// Description property. </summary>
        /// <value>
        /// This is a "friendly name" that should make selection from a pick list easier. This value is required.</value>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// EntryFormatRegEx property. </summary>
        /// <value>
        /// A regular expression that can be used to validate the data in ContextItem.Value. This value is optional.</value>
        public string EntryFormatRegEx
        {
            get { return _entryFormatRegEx; }
            set { _entryFormatRegEx = value; }
        }

        /// <summary>
        /// DisplayFormatRegEx property. </summary>
        /// <value>
        /// A regular expression that can be used to format the ContextItem.Value for display. This value is optional.</value>
        public string DisplayFormatRegEx
        {
            get { return _displayFormatRegEx; }
            set { _displayFormatRegEx = value; }
        }

        /// <summary>
        /// GeoPoliticalContextIds list property. </summary>
        /// <value>
        /// List of GeoPoliticalContext.Id.ReferenceId values. Relevant for understanding in what group or geography the included DisplayFormatRegEx and/or EntryFormatRegEx is used to control the presentation of the ContextItem.Value resulting from the usage of the ContextItemDefinition this Presentation is attached to. This value is optional.</value>
        public List<int> GeoPoliticalContextIds
        {
            get { return _geopoliticalContextIds; }
            set { _geopoliticalContextIds = value; }
        }

    }
}