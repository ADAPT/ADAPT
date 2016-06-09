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

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    /// <summary>
    /// We will use the IANA Language Subtag Registry 
    /// (http://www.iana.org/assignments/language-subtag-registry/language-subtag-registry) as our starting point. 
    /// We'll add entries as needed and objects will be used by reference. This resource is helpful in 
    /// understanding their composition (https://www.w3.org/International/articles/language-tags/index.en).
    /// </summary>
    public class Language
    {
        /// <summary>
        /// The class constructor. </summary>
        public Language()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        /// <summary>
        /// Id property. </summary>
        /// <value>
        /// This will give us a locally-scoped, simplified identifier to use in referencing the object within Lexicalization. This value is required.</value>
        public CompoundIdentifier Id { get; private set; }

        /// <summary>
        /// Code property. </summary>
        /// <value>
        /// This is a "friendly code" that should make querying easier. This value is required.</value>
        public string Code { get; set; }

        /// <summary>
        /// Description property. </summary>
        /// <value>
        /// This is a "friendly name" that should make selection from a pick list easier. This value is required.</value>
        public string Description { get; set; }
    }
}