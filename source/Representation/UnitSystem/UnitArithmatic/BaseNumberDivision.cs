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

namespace AgGateway.ADAPT.Representation.UnitSystem.UnitArithmatic
{
    internal class BaseNumberDivision
    {
        private readonly UnitOfMeasureDecomposer _decomposer;
        private readonly UnitOfMeasureComponentSimplifier _simplifier;

        public BaseNumberDivision(IUnitOfMeasureConverter converter)
        {
            _decomposer = new UnitOfMeasureDecomposer();
            _simplifier = new UnitOfMeasureComponentSimplifier(converter);
        }

        public BaseNumber Divide(BaseNumber numerator, BaseNumber denominator)
        {
            if (denominator.SourceValue == 0.0)
                throw new DivideByZeroException();

            var numeratorComponets = _decomposer.GetComponents(numerator.SourceUnitOfMeasure, 1);
            var denominatorComponents = _decomposer.GetComponents(denominator.SourceUnitOfMeasure, -1);
            var allComponents = numeratorComponets.Union(denominatorComponents).ToList();
            return _simplifier.Simplify(allComponents, numerator.SourceValue / denominator.SourceValue);
        }
    }
}
