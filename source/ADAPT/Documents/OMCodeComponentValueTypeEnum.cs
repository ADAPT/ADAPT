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
    public enum OMCodeComponentValueTypeEnum // Specifies the data type represented by an OMCodeComponent value (string).
    {
        Enum,    // The value is a token, and comes from a code list. 
        Bool,    // The value should be interpreted as an XML-formatted boolean.
        String,  // The value should be interpreted as a string. 
        Double,  // The value should be interpreted as a floating-point number. 
        Integer, // The value should be interpreted as an integer. 
        DateTime // The value should be interpreted as an XML-formatted DateTime.
    }

}
