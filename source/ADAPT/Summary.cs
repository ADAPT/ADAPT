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
 *    Kathleen Oneal - added properties, growerId, FarmIds, FieldIds, CropZoneIds
 *******************************************************************************/

using System.Collections.Generic;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public class Summary
    {
        public int? GrowerId { get; set; }

        public List<int> FarmIds { get; set; }

        public List<int> FieldIds { get; set; }
        
        public List<int> CropZoneIds { get; set; }
    }
}