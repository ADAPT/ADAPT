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
    /// This object is used by value inside ContextItemDefinition.Lexicalizations or ContextItemEnumItem.Lexicalizations.
    /// </summary>
    public class Lexicalization
    {
        public Lexicalization()
        {
            GeoPoliticalContextIds = new List<int>();
        }

        /// <summary>
        /// Text property. </summary>
        /// <value>
        /// Text used to describe the concept expressed by the ContextItemDefinition or ContextItemEnumItem this Lexicalization is attached to. This value is required.</value>
        public string Text { get; set; }

        /// <summary>
        /// LanguageId property. </summary>
        /// <value>
        /// The Language.Id.ReferenceId that indicates what language the text is in. This value is required.</value>
        public int LanguageId { get; set; }

        /// <summary>
        /// GeoPoliticalContextIds list property. </summary>
        /// <value>
        /// List of GeoPoliticalContext.Id.ReferenceId values. Relevant for understanding in what group or geography the included Text is used to describe the ContextItemDefinition or ContextItemEnumItem this Lexicalization is attached to. This value is optional.</value>
        public List<int> GeoPoliticalContextIds { get; set; }
    }
}