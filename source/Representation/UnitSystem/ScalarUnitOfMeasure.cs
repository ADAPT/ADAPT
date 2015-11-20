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

using System.Globalization;
using System.Linq;
using AgGateway.ADAPT.Representation.Generated;

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public class ScalarUnitOfMeasure : UnitOfMeasure
    {
        public double Scale { get; private set; }

        public double BaseOffset { get; private set; }

        public ScalarUnitOfMeasure(UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasure unitOfMeasure, UnitDimension unitDimension) 
            : this(unitOfMeasure, unitDimension, CultureInfo.CurrentUICulture)
        {
        }

        public ScalarUnitOfMeasure(UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasure unitOfMeasure, UnitDimension unitDimension, CultureInfo culture)
        {
            var name = GetName(unitOfMeasure.Name, culture);

            Label = unitOfMeasure.Name != null ? name.label : null;
            LabelPlural = unitOfMeasure.Name != null ? name.plural : null;
            DomainID = unitOfMeasure.domainID;
            UomId = unitOfMeasure.uomID;
            BaseOffset = unitOfMeasure.baseOffset;
            Scale = unitOfMeasure.scale;
            UnitDimension = unitDimension;
        }

        private static UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasureName GetName(UnitSystemUnitDimensionUnitDimensionRepresentationUnitOfMeasureName[] names, CultureInfo culture)
        {
            if (names == null)
                return null;

            return names.SingleOrDefault(n => n.locale == culture.TwoLetterISOLanguageName)
                ?? names.Single(n => n.locale == CultureInfoDefault.DefaultCulture);
        }

        public override string Label { get; protected set; }
        public override string LabelPlural { get; protected set; }
        public UnitDimension UnitDimension { get; set; }
    }
}