/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Justin Sliekers - initial API and implementation
  *    Kelly Nelson - Marking default rates obsolete in favor of per-product default rates
  *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using System;

namespace AgGateway.ADAPT.ApplicationDataModel.Prescriptions
{
    public class SpatialPrescription : Prescription
    {
        public BoundingBox BoundingBox { get; set; }

        [Obsolete("Set out of field rates on each RxProductLookup")]
        public NumericRepresentationValue OutOfFieldRate { get; set; }

        [Obsolete("Set loss of GPS rates on each RxProductLookup")]
        public NumericRepresentationValue LossOfGpsRate { get; set; }
    }
}
