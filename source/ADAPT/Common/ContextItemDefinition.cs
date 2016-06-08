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
    /// Enumeration describing what type of value to expect. </summary>
    /// <remarks>
    /// ContextItem.Value is always of type String. In some cases (Bool, String, Double, Integer), this
    ///  enumeration indicates the data type to which the user is expected to cast the value. </remarks>
    public enum ContextItemValueTypeEnum
    {
        Nested = 0,
        Enum = 1,
        Bool = 2,
        String = 3,
        Double = 4,
        Integer = 5
    }

    public class ContextItemDefinition
    {
        /// <summary>
        /// Store for the Id property.</summary>
        private CompoundIdentifier _id = null;
        /// <summary>
        /// Store for the ParentId property.</summary>
        private int? _parentId = null;
        /// <summary>
        /// Store for the Code property.</summary>
        private string _code = null;
        /// <summary>
        /// Store for the Version property.</summary>
        private int _version = 0;
        /// <summary>
        /// Store for the ValueType property.</summary>
        private ContextItemValueTypeEnum _valueType;
        /// <summary>
        /// Store for the Description property.</summary>
        private string _description = null;
        /// <summary>
        /// Store for the Keywords list property.</summary>
        private List<string> _keywords;
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
        /// Store for the NestedItemIds list property.</summary>
        private List<int> _nestedDefIds;
        /// <summary>
        /// Store for the Presentations list property.</summary>
        private List<Presentation> _presentations;
        /// <summary>
        /// Store for the EnumItems list property.</summary>
        private List<ContextItemEnumItem> _enumItems;
        /// <summary>
        /// Store for the DefaultUOM property.</summary>
        private string _defaultUOM = null;
        /// <summary>
        /// Store for the AllowConversion property.</summary>
        private bool _allowConversion = false;
        /// <summary>
        /// Store for the TimeScopes list property.</summary>
        private List<TimeScope> _timeScopes;
        /// <summary>
        /// Store for the ModelScopes list property.</summary>
        private List<int> _modelScopeIds;
        /// <summary>
        /// Store for the GeoPoliticalContextRefs list property.</summary>
        private List<int> _geopoliticalContextIds;

        /// <summary>
        /// The class constructor. </summary>
        public ContextItemDefinition()
        {
            _keywords = new List<string>();
            _lexicalizations = new List<Lexicalization>();
            _properties = new List<ContextItem>();
            _nestedDefIds = new List<int>();
            _presentations = new List<Presentation>();
            _enumItems = new List<ContextItemEnumItem>();
            _timeScopes = new List<TimeScope>();
            _modelScopeIds = new List<int>();
            _geopoliticalContextIds = new List<int>();
        }

        /// <summary>
        /// Id property. </summary>
        /// <value>
        /// The CompoundIdentifier that allows this ContextItemDefinition to be directly addressed in a collection. This value is required.</value>
        public CompoundIdentifier Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// ParentId property. </summary>
        /// <value>
        /// Populated if this ContextItemDefiniton is a "child" of a Nested ContextItemDefinition. This value is optional.</value>
        public int? ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        /// <summary>
        /// Code property. </summary>
        /// <value>
        /// The code that will represent this ContextItemDefinition in data transfer. Required to be universally unique. This value is required.</value>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        /// Version property. </summary>
        /// <value>
        /// The current version number of the ContextItemDefinition. Used for change detection, increment if any member (including sub objects) has been modified. This value is required.</value>
        public int Version
        {
            get { return _version; }
            set { _version = value; }
        }

        /// <summary>
        /// ValueType property. </summary>
        /// <value>
        /// What is the data type of the value expected in the ContextItem? Use "Nested" for nested ContextItems. This value is required.</value>
        public ContextItemValueTypeEnum ValueType
        {
            get { return _valueType; }
            set { _valueType = value; }
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
        /// Keywordss list property. </summary>
        /// <value>
        /// List of keywords that allows easier querying. This value is optional.</value>
        public List<string> Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }

        /// <summary>
        /// AgGlossaryURL property. </summary>
        /// <value>
        /// URL pointing to an entry in agglossary.org that corresponds to the concept described by this ContextItemDefinition. This value is optional.</value>
        public string AgGlossaryURL
        {
            get { return _agGlossaryURL; }
            set { _agGlossaryURL = value; }
        }

        /// <summary>
        /// AgrovocURL property. </summary>
        /// <value>
        /// URL pointing to an entry in AGROVOC that corresponds to the concept described by this ContextItemDefinition. This value is optional.</value>
        public string AgrovocURL
        {
            get { return _agrovocURL; }
            set { _agrovocURL = value; }
        }

        /// <summary>
        /// Lexicalizations list property. </summary>
        /// <value>
        /// List of Lexicalization that contains different ways of expressing the concept represented by the ContextItemDefiniton. This value is optional.</value>
        public List<Lexicalization> Lexicalizations
        {
            get { return _lexicalizations; }
            set { _lexicalizations = value; }
        }

        /// <summary>
        /// Properties list property. </summary>
        /// <value>
        /// List of ContextItem that contain additional data required for the proper use and understanding of the ContextItemDefiniton. This value is optional.</value>
        public List<ContextItem> Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }

        /// <summary>
        /// NestedDefIds list property. </summary>
        /// <value>
        /// List of "nested" ContextItemDefinition.Id.ReferenceId; only populated if the ValueType is "Nested". This value is optional.</value>
        public List<int> NestedDefIds
        {
            get { return _nestedDefIds; }
            set { _nestedDefIds = value; }
        }

        /// <summary>
        /// Presentations list property. </summary>
        /// <value>
        /// List of Presentation that contains different ways of validating the input or formatting the display of the value represented by the ContextItemDefiniton. This value is optional.</value>
        public List<Presentation> Presentations
        {
            get { return _presentations; }
            set { _presentations = value; }
        }

        /// <summary>
        /// EnumItems list property. </summary>
        /// <value>
        /// List of ContextItemEnumItem that holds the available options if the ContextItemDefinition is an enumeration. This value is optional.</value>
        public List<ContextItemEnumItem> EnumItems
        {
            get { return _enumItems; }
            set { _enumItems = value; }
        }

        /// <summary>
        /// DefaultUOM property. </summary>
        /// <value>
        /// The assumed unit of measure for the ContextItem.Value. This value is optional.</value>
        public string DefaultUOM
        {
            get { return _defaultUOM; }
            set { _defaultUOM = value; }
        }

        /// <summary>
        /// AllowConversion property. </summary>
        /// <value>
        /// This flag determines if the ContextItem user is allowed to convert from the DefaultUOM to a compatible unit. This value is optional.</value>
        public bool AllowConversion
        {
            get { return _allowConversion; }
            set { _allowConversion = value; }
        }

        /// <summary>
        /// TimeScopes list property. </summary>
        /// <value>
        /// List of TimeScope that communicate the time attributes of the ContextItemDefiniton. This value is optional.</value>
        public List<TimeScope> TimeScopes
        {
            get { return _timeScopes; }
            set { _timeScopes = value; }
        }

        /// <summary>
        /// ModelScopes list property. </summary>
        /// <value>
        /// List of ModelScope.Id.ReferenceId that communicate the ADAPT classes and ISO 11783 tags where the ContextItemDefiniton can be used. This value is optional.</value>
        public List<int> ModelScopeIds
        {
            get { return _modelScopeIds; }
            set { _modelScopeIds = value; }
        }

        /// <summary>
        /// GeoPoliticalContexts list property. </summary>
        /// <value>
        /// List of GeoPoliticalContext.Id.ReferenceId that communicate the geographic and/or political domains where the ContextItemDefiniton can be used. This value is optional.</value>
        public List<int> GeoPoliticalContextIds
        {
            get { return _geopoliticalContextIds; }
            set { _geopoliticalContextIds = value; }
        }
    }
}