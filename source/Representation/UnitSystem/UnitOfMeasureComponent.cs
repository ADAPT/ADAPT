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
  *******************************************************************************/

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public class UnitOfMeasureComponent : IUnit
    {
        public UnitOfMeasureComponent(UnitOfMeasure unit, int power)
        {
            Unit = unit;
            Power = power;
        }

        public UnitOfMeasure Unit { get; private set; }
        public int Power { get; private set; } 

        public string DomainID
        {
            get { return Unit.DomainID; }
        }
    }
}