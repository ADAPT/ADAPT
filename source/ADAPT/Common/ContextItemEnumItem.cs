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
    /// This object is used by value inside ContextItemDefinition.EnumItems.
    /// </summary>
    public class ContextItemEnumItem
    {
        /// <summary>
        /// The class constructor. </summary>
        public ContextItemEnumItem()
        {
            Lexicalizations = new List<Lexicalization>();
            Properties = new List<ContextItem>();
        }

        /// <summary>
        /// Value property. </summary>
        /// <value>
        /// This is the value of the enumerated item. Required to be unique in the scope of its parent ContextItemDefinition. This value is required.</value>
        public string Value { get; set; }

        /// <summary>
        /// Version property. </summary>
        /// <value>
        /// The current version number of the ContextItemEnumItem. Used for change detection, increment if any member (including sub objects) has been modified. This value is required.</value>
        public int Version { get; set; }

        /// <summary>
        /// Description property. </summary>
        /// <value>
        /// This is a "friendly name" that should make selection from a pick list easier. This value is required.</value>
        public string Description { get; set; }

        /// <summary>
        /// AgGlossaryURL property. </summary>
        /// <value>
        /// URL pointing to an entry in agglossary.org that corresponds to the concept described by this ContextItemEnumItem. This value is optional.</value>
        public string AgGlossaryURL { get; set; }

        /// <summary>
        /// AgrovocURL property. </summary>
        /// <value>
        /// URL pointing to an entry in AGROVOC that corresponds to the concept described by this ContextItemEnumItem. This value is optional.</value>
        public string AgrovocURL { get; set; }

        /// <summary>
        /// Lexicalizations list property. </summary>
        /// <value>
        /// List of Lexicalization that contains different ways of expressing the concept represented by the ContextItemEnumItem. This value is optional.</value>
        public List<Lexicalization> Lexicalizations { get; set; }

        /// <summary>
        /// Properties list property. </summary>
        /// <value>
        /// List of ContextItem that contain additional data required for the proper use and understanding of the ContextItemEnumItem. This value is optional.</value>
        public List<ContextItem> Properties { get; set; }
    }
}