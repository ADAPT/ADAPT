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
 *    Tarak Reddy - Changed EnumeratedListValueRef to Enumerated Value
 *******************************************************************************/

using System;

namespace AgGateway.ADAPT.ApplicationDataModel
{
    public abstract class Note
    {
        public string Description { get; set; }
        public EnumeratedValue EnumeratedValue { get; set; }
        public DateTime TimeStamp { get; set; }
        public Shape SpatialContext { get; set; }
    }
}