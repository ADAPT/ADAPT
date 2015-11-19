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
using System.Text;
using AgGateway.ADAPT.Representation.Generated;

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public class CompositeConversionFactor : IUnit
    {
        public CompositeConversionFactor(UnitSystemUnitDimensionCompositeUnitDimensionRepresentation representation)
        {
            Scale = representation.scale;
            BaseOffset = representation.baseOffset;
            DomainID = BuildDomainId(representation.UnitDimensionRef);
        }

        public double Scale { get; set; }

        public double BaseOffset { get; set; }

        public string DomainID { get; private set; }

        private string BuildDomainId(IEnumerable<UnitSystemUnitDimensionCompositeUnitDimensionRepresentationUnitDimensionRef> unitRef)
        {
            var domainId = new StringBuilder();
            foreach (var unit in unitRef)
            {
                domainId.Append(unit.baseUnitOfMeasureRef);
                domainId.Append(unit.power);
            }
            return domainId.ToString();
        }
    }
}
