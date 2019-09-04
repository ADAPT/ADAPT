/*******************************************************************************
  * Copyright (C) 2019 AgGateway, ADAPT Contributors, and Syngenta
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  * 4/16/2019 R. Andres Ferreyra created the class transcribing from the X632-2 Observations schema.   
  *    
  *******************************************************************************/

namespace AgGateway.ADAPT.ApplicationDataModel.Documents
{
    public enum OMSemanticResourceStatusEnum // Specifies the lifecycle status of an OMCode, OMCodeComponent, etc.
    {
        Active,     // The code or code component has Active (usable, "official") status in a public data type registry. 
        Deprecated, // The code or code component is deprecated. Do not use for new observations!
        Candidate,  // The code or code component has candidate status: submitted but not yet approved in a public data type registry. 
        Proprietary // The code or code component is proprietary; its definition is unlikely to be available in a public data type registry.
    }

}
