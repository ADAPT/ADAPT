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
  *    Joseph Ross - Adding intializer for id
  *******************************************************************************/

using System.Collections.Generic;

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
        /// The class constructor. </summary>
        public ContextItemDefinition()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            Keywords = new List<string>();
            Lexicalizations = new List<Lexicalization>();
            Properties = new List<ContextItem>();
            NestedDefIds = new List<int>();
            Presentations = new List<Presentation>();
            EnumItems = new List<ContextItemEnumItem>();
            TimeScopes = new List<TimeScope>();
            ModelScopeIds = new List<int>();
            GeoPoliticalContextIds = new List<int>();
        }

        /// <summary>
        /// Id property. </summary>
        /// <value>
        /// The CompoundIdentifier that allows this ContextItemDefinition to be directly addressed in a collection. This value is required.</value>
        public CompoundIdentifier Id { get; private set; }

        /// <summary>
        /// ParentId property. </summary>
        /// <value>
        /// Populated if this ContextItemDefiniton is a "child" of a Nested ContextItemDefinition. This value is optional.</value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Code property. </summary>
        /// <value>
        /// The code that will represent this ContextItemDefinition in data transfer. Required to be universally unique. This value is required.</value>
        public string Code { get; set; }

        /// <summary>
        /// Version property. </summary>
        /// <value>
        /// The current version number of the ContextItemDefinition. Used for change detection, increment if any member (including sub objects) has been modified. This value is required.</value>
        public int Version { get; set; }

        /// <summary>
        /// ValueType property. </summary>
        /// <value>
        /// What is the data type of the value expected in the ContextItem? Use "Nested" for nested ContextItems. This value is required.</value>
        public ContextItemValueTypeEnum ValueType { get; set; }

        /// <summary>
        /// Description property. </summary>
        /// <value>
        /// This is a "friendly name" that should make selection from a pick list easier. This value is required.</value>
        public string Description { get; set; }

        /// <summary>
        /// Keywordss list property. </summary>
        /// <value>
        /// List of keywords that allows easier querying. This value is optional.</value>
        public List<string> Keywords { get; set; }

        /// <summary>
        /// AgGlossaryURL property. </summary>
        /// <value>
        /// URL pointing to an entry in agglossary.org that corresponds to the concept described by this ContextItemDefinition. This value is optional.</value>
        public string AgGlossaryURL { get; set; }

        /// <summary>
        /// AgrovocURL property. </summary>
        /// <value>
        /// URL pointing to an entry in AGROVOC that corresponds to the concept described by this ContextItemDefinition. This value is optional.</value>
        public string AgrovocURL { get; set; }

        /// <summary>
        /// Lexicalizations list property. </summary>
        /// <value>
        /// List of Lexicalization that contains different ways of expressing the concept represented by the ContextItemDefiniton. This value is optional.</value>
        public List<Lexicalization> Lexicalizations { get; set; }

        /// <summary>
        /// Properties list property. </summary>
        /// <value>
        /// List of ContextItem that contain additional data required for the proper use and understanding of the ContextItemDefiniton. This value is optional.</value>
        public List<ContextItem> Properties { get; set; }

        /// <summary>
        /// NestedDefIds list property. </summary>
        /// <value>
        /// List of "nested" ContextItemDefinition.Id.ReferenceId; only populated if the ValueType is "Nested". This value is optional.</value>
        public List<int> NestedDefIds { get; set; }

        /// <summary>
        /// Presentations list property. </summary>
        /// <value>
        /// List of Presentation that contains different ways of validating the input or formatting the display of the value represented by the ContextItemDefiniton. This value is optional.</value>
        public List<Presentation> Presentations { get; set; }

        /// <summary>
        /// EnumItems list property. </summary>
        /// <value>
        /// List of ContextItemEnumItem that holds the available options if the ContextItemDefinition is an enumeration. This value is optional.</value>
        public List<ContextItemEnumItem> EnumItems { get; set; }

        /// <summary>
        /// DefaultUOM property. </summary>
        /// <value>
        /// The assumed unit of measure for the ContextItem.Value. This value is optional.</value>
        public string DefaultUOM { get; set; }

        /// <summary>
        /// AllowConversion property. </summary>
        /// <value>
        /// This flag determines if the ContextItem user is allowed to convert from the DefaultUOM to a compatible unit. This value is optional.</value>
        public bool AllowConversion { get; set; }

        /// <summary>
        /// TimeScopes list property. </summary>
        /// <value>
        /// List of TimeScope that communicate the time attributes of the ContextItemDefiniton. This value is optional.</value>
        public List<TimeScope> TimeScopes { get; set; }

        /// <summary>
        /// ModelScopes list property. </summary>
        /// <value>
        /// List of ModelScope.Id.ReferenceId that communicate the ADAPT classes and ISO 11783 tags where the ContextItemDefiniton can be used. This value is optional.</value>
        public List<int> ModelScopeIds { get; set; }

        /// <summary>
        /// GeoPoliticalContexts list property. </summary>
        /// <value>
        /// List of GeoPoliticalContext.Id.ReferenceId that communicate the geographic and/or political domains where the ContextItemDefiniton can be used. This value is optional.</value>
        public List<int> GeoPoliticalContextIds { get; set; }
    }
}