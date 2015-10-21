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

using System.Linq;

namespace AgGateway.ADAPT.Representation.UnitSystem.UnitArithmatic
{
    internal class BaseNumberMultiplication 
    {
        private readonly UnitOfMeasureDecomposer _decomposer;
        private readonly UnitOfMeasureComponentSimplifier _simplifier;

        public BaseNumberMultiplication(IUnitOfMeasureConverter converter)
        {
            _decomposer = new UnitOfMeasureDecomposer();
            _simplifier = new UnitOfMeasureComponentSimplifier(converter);
        }

        public INumber Multiply(INumber left, INumber right)
        {
            var leftComponents = _decomposer.GetComponents(left.SourceUnitOfMeasure, 1);
            var rightComponents = _decomposer.GetComponents(right.SourceUnitOfMeasure, 1);
            var allComponents = leftComponents.Union(rightComponents).ToList();

            return _simplifier.Simplify(allComponents, left.SourceValue * right.SourceValue);
        }
    }
}
