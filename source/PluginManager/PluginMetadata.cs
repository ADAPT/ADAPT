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
  *******************************************************************************/  

using System;
using AgGateway.ADAPT.ApplicationDataModel;

namespace Adapt.PluginManager
{
    public class PluginMetadata
    {
        public string Name { get; set; }
        public Version ModelVersion { get; set; }
        public IPlugin AssemblyInstance { get; set; }
        public string EntryClass { get; set; }
        public string AssemblyLocation { get; set; }
    }
}
