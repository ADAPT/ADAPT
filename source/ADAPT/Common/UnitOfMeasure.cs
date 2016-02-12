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
  *    Kathleen Oneal - renamed UnitDiminesion to Dimension; removed Name, Symbol, ConversionScale, Conversion Offset; added IsReferenceForDimension, Scale, Offset
  *******************************************************************************/

using System;

namespace AgGateway.ADAPT.ApplicationDataModel.Common
{
    public class UnitOfMeasure : MarshalByRefObject
    {
        public UnitOfMeasure()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public string Code { get; set; }

        public UnitOfMeasureDimensionEnum Dimension { get; set; }

        public bool IsReferenceForDimension{ get; set; }

        public double Scale { get; set; }

        public double Offset { get; set; }

    }
}