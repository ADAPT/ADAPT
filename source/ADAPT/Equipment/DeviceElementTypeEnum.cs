/*******************************************************************************
 * Copyright (C) 2016, 2018 AgGateway and ADAPT Contributors
 * Copyright (C) 2016 Deere and Company
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors:
 *    Justin Sliekers - implement device element changes, initial creation
 *    R. Andres Ferreyra - Adding 3 Irrigation-related items: IrrSystem, IrrSection, and Endgun
 *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public enum DeviceElementTypeEnum
    {
        Machine,
        Implement,
        Sensor,
        Bin,
        Section,
        Unit,
        Function,
        IrrSystem, // A mobile or fixed irrigation system such as a center pivot, linear, traveling gun, solid set, etc.
        IrrSection, // A section of an IrrSystem. Different enough from a regular section to merit its own DeviceElementConfiguration
        Endgun // A device attached to an irrigation system that projects water beyond it.
     }
}
