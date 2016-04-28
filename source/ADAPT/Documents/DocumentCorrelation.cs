/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Kathleen Oneal - initial API and implementation
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public class DocumentCorrelation
    {
        public CompoundIdentifier Id { get; set; }

        public DocRelationshipTypeEnum RelationshipType { get; set; }

        public int DocumentId { get; set; }

        public int CorrelatingDocumentId { get; set; }

        public List<TimeScope> TimeScopes { get; set; }

        public List<int> PersonRoleIds { get; set; }
    }
}
