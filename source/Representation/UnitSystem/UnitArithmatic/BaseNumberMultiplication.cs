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
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods;

namespace AgGateway.ADAPT.Representation.UnitSystem.UnitArithmatic
{
   internal class BaseNumberMultiplication
   {
      public static NumericValue Multiply(NumericValue left, NumericValue right)
      {
         var decomposer = new UnitOfMeasureDecomposer();
         var leftComponents = decomposer.GetComponents(left.UnitOfMeasure.ToInternalUom(), 1);
         var rightComponents = decomposer.GetComponents(right.UnitOfMeasure.ToInternalUom(), 1);
         var allComponents = leftComponents.Union(rightComponents).ToList();

         return new UnitOfMeasureComponentSimplifier().Simplify(allComponents, left.Value * right.Value);
      }
   }
}
