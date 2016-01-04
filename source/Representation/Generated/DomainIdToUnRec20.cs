/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tim Shearouse - initial API and implementation
  *******************************************************************************/
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AgGateway.ADAPT.Representation.Generated
{
    [DataContract]
    public class Root
    {
        [DataMember]
        public List<Row> Rows;
    }

    [DataContract]
    public class Row
    {
        [DataMember]
        public string UnRec20;

        [DataMember]
        public string DomainId;
    }
}
