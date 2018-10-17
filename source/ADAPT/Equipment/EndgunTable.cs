/*******************************************************************************
  * Copyright (C) 2016 AgGateway and ADAPT Contributors
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors: Aaron Berger: Transcribed from PAIL
  *    
  *******************************************************************************/
 
using System.Collections.Generic;
namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class EndgunTable
    {
        public EndgunTable()
        {
             TableEntries = new List<EndgunTableEntry>();
         }
        public List<EndgunTableEntry> TableEntries { get; set; }
     }
}
