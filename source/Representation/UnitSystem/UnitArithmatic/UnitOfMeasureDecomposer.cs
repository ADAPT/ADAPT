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

using System.Collections.Generic;

namespace AgGateway.ADAPT.Representation.UnitSystem.UnitArithmatic
{
    internal class UnitOfMeasureDecomposer
    {
        public IEnumerable<UnitOfMeasureComponent>  GetComponents(UnitOfMeasure unitOfMeasure, int power)
        {
            var components = new List<UnitOfMeasureComponent>();
            var compositeUnitOfMeasure = unitOfMeasure as CompositeUnitOfMeasure;
            if (compositeUnitOfMeasure == null)
            {
                components.Add(new UnitOfMeasureComponent(unitOfMeasure, power));
                return components;
            }

            foreach (var component in compositeUnitOfMeasure.Components)
                components.AddRange(GetComponents(component.Unit, component.Power * power));

            return components;
        }
    }
}