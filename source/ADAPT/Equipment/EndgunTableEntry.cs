 /*******************************************************************************
  * Copyright (C) 2018 AgGateway and ADAPT Contributors
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors: Aaron Berger, Andres Ferreyra: Translated from PAIL
  *    
  *******************************************************************************/
 
 using AgGateway.ADAPT.ApplicationDataModel.Representations;
 namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class EndgunTableEntry
    {
        public NumericRepresentationValue Pressure { get; set; }
        public NumericRepresentationValue FlowValue { get; set; }
        public NumericRepresentationValue ThrowValue { get; set; }
     }
}