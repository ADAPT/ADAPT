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
using System.Text;
using System.Threading.Tasks;

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    /// <summary>
    /// This object is used by value inside ContextItemDefinition.EnumItems.
    /// </summary>
    public class ContextItemEnumItem
    {
        /// <summary>
        /// Store for the Value property.</summary>
        private string _value = null;
        /// <summary>
        /// Store for the Version property.</summary>
        private int _version = 0;
        /// <summary>
        /// Store for the Description property.</summary>
        private string _description = null;
        /// <summary>
        /// Store for the AgGlossaryURL property.</summary>
        private string _agGlossaryURL = null;
        /// <summary>
        /// Store for the AgrovocURL property.</summary>
        private string _agrovocURL = null;
        /// <summary>
        /// Store for the Lexicalizations list property.</summary>
        private List<Lexicalization> _lexicalizations;
        /// <summary>
        /// Store for the Properties list property.</summary>
        private List<ContextItem> _properties;

        /// <summary>
        /// The class constructor. </summary>
        public ContextItemEnumItem()
        {
            _lexicalizations = new List<Lexicalization>();
            _properties = new List<ContextItem>();
        }

        /// <summary>
        /// Value property. </summary>
        /// <value>
        /// This is the value of the enumerated item. Required to be unique in the scope of its parent ContextItemDefinition. This value is required.</value>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Version property. </summary>
        /// <value>
        /// The current version number of the ContextItemEnumItem. Used for change detection, increment if any member (including sub objects) has been modified. This value is required.</value>
        public int Version
        {
            get { return _version; }
            set { _version = value; }
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
        /// AgGlossaryURL property. </summary>
        /// <value>
        /// URL pointing to an entry in agglossary.org that corresponds to the concept described by this ContextItemEnumItem. This value is optional.</value>
        public string AgGlossaryURL
        {
            get { return _agGlossaryURL; }
            set { _agGlossaryURL = value; }
        }

        /// <summary>
        /// AgrovocURL property. </summary>
        /// <value>
        /// URL pointing to an entry in AGROVOC that corresponds to the concept described by this ContextItemEnumItem. This value is optional.</value>
        public string AgrovocURL
        {
            get { return _agrovocURL; }
            set { _agrovocURL = value; }
        }

        /// <summary>
        /// Lexicalizations list property. </summary>
        /// <value>
        /// List of Lexicalization that contains different ways of expressing the concept represented by the ContextItemEnumItem. This value is optional.</value>
        public List<Lexicalization> Lexicalizations
        {
            get { return _lexicalizations; }
            set { _lexicalizations = value; }
        }

        /// <summary>
        /// Properties list property. </summary>
        /// <value>
        /// List of ContextItem that contain additional data required for the proper use and understanding of the ContextItemEnumItem. This value is optional.</value>
        public List<ContextItem> Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }
    }
}