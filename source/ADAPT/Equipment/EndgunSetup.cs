/*******************************************************************************
 * Copyright (C) 2018 AgGateway and ADAPT Contributors
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors: Aaron Berger: Translate from PAIL Part 3 Schema
 *    
 *******************************************************************************/


namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class EndgunSetup
    {
        public int ManufacturerId { get; set; }
        public int ModelId { get; set; }
        public EndgunTableEntry NominalValues { get; set; }
        public EndgunTable TabularValues { get; set; }
    }
}
