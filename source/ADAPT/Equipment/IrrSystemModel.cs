/*******************************************************************************
 * Copyright (C) 2018 AgGateway and ADAPT Contributors
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors: Aaron Berger, R. Andres Ferreyra: Porting and adapting from PAIL 
 *    
 *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class IrrSystemModel : DeviceModel
    {
        public IrrSystemModel()
        {

        }

        public IrrSystemTypeEnum SysType { get; set; }    }
}