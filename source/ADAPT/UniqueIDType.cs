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
  *    Joseph Ross - Renaming Enums to end in Enum
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class UniqueIDType
    {
        public string ID { get; set; }
        public CompoundIdentifierTypeEnum CiTypeEnum { get; set; }
        public string Source { get; set; }
        public SourceTypeEnum SourceTypeEnum { get; set; }
        public bool IsFirstSource { get; set; }
    }

    public enum CompoundIdentifierTypeEnum
    {
        UUID,
        GLN,
        URI,
        String,
        Long
    }

    public enum SourceTypeEnum
    {
        GLN,
        URI
    }
}