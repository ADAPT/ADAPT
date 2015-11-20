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

using System;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods;

namespace AgGateway.ADAPT.Representation.UnitSystem.UnitArithmatic
{
    internal class BaseNumberDivision
    {
        public static NumericValue Divide(NumericValue numerator, NumericValue denominator)
        {
            if (denominator.Value == 0.0)
                throw new DivideByZeroException();

            var decomposer = new UnitOfMeasureDecomposer();
            var numeratorComponets = decomposer.GetComponents(numerator.UnitOfMeasure.ToInternalUom(), 1);
            var denominatorComponents = decomposer.GetComponents(denominator.UnitOfMeasure.ToInternalUom(), -1);
            var allComponents = numeratorComponets.Union(denominatorComponents).ToList();
            return new UnitOfMeasureComponentSimplifier().Simplify(allComponents, numerator.Value / denominator.Value);
        }
    }
}
