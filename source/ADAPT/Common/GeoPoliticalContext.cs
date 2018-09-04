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
  *    R. Andres Ferreyra - Added GPCLevel, GPCVocSource, Lexicalizations 
  *******************************************************************************/
using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    /// <summary>
    /// If the GPCVocSource is not present, we assume the FAO's Geopolitical Ontology (http://www.fao.org/countryprofiles/geoinfo/en/).
    /// For example,
    /// it contains economic regions(EU) and organizations(FAO), but not the individual US states. We'll add entries as 
    /// needed and objects will be used by reference.
    /// </summary>
    public class GeoPoliticalContext
    {
        /// <summary>
        /// The class constructor. </summary>
        public GeoPoliticalContext()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
            Lexicalizations = new List<Lexicalization>();
        }

        /// <summary>
        /// Id property. </summary>
        /// <value>
        /// This will give us a locally-scoped, simplified identifier to use in referencing the object within ContextItemDefinition, Presentation, and Lexicalization; as well as the opportunity to use the ontology URI as a unique identifier. This value is required.</value>
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
 
 
        /// <summary>
        /// GPCLevel property. </summary>
        /// <value>
        /// Describes whether the GPC is a country, level-1 administrative unit (e.g., state or province), or a level-2 unit (e.g., county).</value>
        public GPCLevelEnum? GPCLevel { get; set; }

        /// <summary>
        /// GPCVocSource property. </summary>
        /// <value>
        /// Describes the organization that minted the GPC code: an ISO standard, GeoNames, FAO Geopolitical Ontology.</value>
        public GPCSourceVocEnum? GPCVocSource { get; set; }

        /// <summary>
        /// Lexicalizations property. </summary>
        /// <value>
        /// Provides strings human-readable labels for the geopolitical context, in specific languages.</value>
        public List<Lexicalization> Lexicalizations { get; set; }
    }
}
