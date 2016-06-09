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
    /// This object is used by value inside ContextItemDefinition.Presentations.
    /// </summary>
    public class Presentation
    {
        public Presentation()
        {
            GeoPoliticalContextIds = new List<int>();
        }

        /// <summary>
        /// Description property. </summary>
        /// <value>
        /// This is a "friendly name" that should make selection from a pick list easier. This value is required.</value>
        public string Description { get; set; }

        /// <summary>
        /// EntryFormatRegEx property. </summary>
        /// <value>
        /// A regular expression that can be used to validate the data in ContextItem.Value. This value is optional.</value>
        public string EntryFormatRegEx { get; set; }

        /// <summary>
        /// DisplayFormatRegEx property. </summary>
        /// <value>
        /// A regular expression that can be used to format the ContextItem.Value for display. This value is optional.</value>
        public string DisplayFormatRegEx { get; set; }

        /// <summary>
        /// GeoPoliticalContextIds list property. </summary>
        /// <value>
        /// List of GeoPoliticalContext.Id.ReferenceId values. Relevant for understanding in what group or geography the included DisplayFormatRegEx and/or EntryFormatRegEx is used to control the presentation of the ContextItem.Value resulting from the usage of the ContextItemDefinition this Presentation is attached to. This value is optional.</value>
        public List<int> GeoPoliticalContextIds { get; set; }
    }
}