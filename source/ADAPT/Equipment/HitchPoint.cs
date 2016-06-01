/*******************************************************************************
 * Copyright (C) 2016 AgGateway and ADAPT Contributors
 * Copyright (C) 2016 Deere and Company
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors:
 *    Justin Sliekers - implement device element changes, initial creation
 *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Common;

namespace AgGateway.ADAPT.ApplicationDataModel.Equipment
{
    public class HitchPoint
    {
        public HitchPoint()
        {
            Id = CompoundIdentifierFactory.Instance.Create();
        }

        public CompoundIdentifier Id { get; private set; }

        public HitchTypeEnum HitchTypeEnum { get; set; }

        public int RefPoint { get; set; }
    }
}
