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
    public enum OMSemanticResourceLevelEnum // Specifies the content of an OMPartsList.
    {
        OMCode,                // The list contains OMCodes. 
        OMCodeComponent,       // The list contains OMCodeComponents.
        CodeComponentType,     // The list contains CodeComponent.CodeComponentType values. 
        CodeComponentSelector, // The list contains CodeComponent.CodeComponentSelector values. 
        CodeComponentValue,    // The list contains CodeComponent.CodeComponentValue values. 
        CodeComponentUoM       // The list contains CodeComponent.CodeComponentUoM values.
    }

}
