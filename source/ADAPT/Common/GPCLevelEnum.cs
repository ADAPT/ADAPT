/*******************************************************************************
  * Copyright (C) 2018 AgGateway and ADAPT Contributors
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    R. Andres Ferreyra - initial port from PAIL Obs schema

  *******************************************************************************/  

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    /// <summary>
    /// Describes the hierarchical level of the geopolitical context:
    /// - Country
    /// - Administrative level 1 (e.g., US States, Canadian provinces, Russian oblasts) 
    /// - Administrative level 2 (e.g., US counties)
    /// </summary>
    public enum GPCLevelEnum
    {
        Country,
        ADM1,
        ADM2
    }
}
