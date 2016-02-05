/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *    Kathleen Oneal - added estimatedArea
  *******************************************************************************/

using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Notes;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public abstract class Document
    {
        protected Document()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public List<ContextItem> ContextItems { get; set; }

        public List<int> CropIds { get; set; }

        public List<int> CropZoneIds { get; set; }

        public string Description { get; set; }

        public NumericRepresentationValue EstimatedArea { get; set; }

        public List<int> FarmIds { get; set; }

        public List<int> FieldIds { get; set; }

        public int? GrowerId { get; set; }

        public List<Note> Notes { get; set; }

        public List<int> PersonRoleIds { get; set; }

        public List<int> TimeScopeIds { get; set; }

        public int? Version { get; set; }
    }
}