/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tim Shearouse - initial API and implementation
  *    Kelly Nelson - adding OutOfFieldRate and LossOfGpsRate
  *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ApplicationDataModel.Prescriptions
{
    public class RxProductLookup
    {
        public RxProductLookup()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public int? ProductId { get; set; }
        
        public NumericRepresentation Representation { get; set; }
        
        public UnitOfMeasure UnitOfMeasure { get; set; }

        /// <summary>
        /// The rate to use for this product when the implement is outside the defined area
        /// </summary>
        public NumericRepresentationValue OutOfFieldRate { get; set; }

        /// <summary>
        /// The default rate to use for this product should the implement lose GPS signal
        /// </summary>
        public NumericRepresentationValue LossOfGpsRate { get; set; }
    }
}
