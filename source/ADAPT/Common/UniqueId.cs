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
  *    Kathleen Oneal - Renamed SourceTypeEnum to SourceType, moved enums to their own files
  *    Kathleen Oneal - renamed from UniqueIdType to UniqueId
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    public class UniqueId
    {
        public string Id { get; set; }
        
        public CompoundIdentifierTypeEnum CiTypeEnum { get; set; }
        
        public string Source { get; set; }
        
        public IdSourceTypeEnum? SourceType { get; set; }
    }
}