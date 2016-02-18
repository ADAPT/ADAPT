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
  *    Kathleen Oneal - renamed from NumericalValue to NumericValue
  *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Representations
{
    public class NumericValue
    {
        public double Value { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }

        public NumericValue(UnitOfMeasure uom, double value)
        {
            UnitOfMeasure = uom;
            Value = value;
        }
    }
}