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
using System.Globalization;
using System.Linq;
using AgGateway.ADAPT.Representation.Generated;

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public class UnitType : IUnit
    {
        public string Name { get; private set; }
        public string DomainID { get; private set; }
        public UnitOfMeasureCollection Units { get; private set; }
        public List<CompositeConversionFactor> CompositeEquivalents { get; set; } 

        public UnitType(UnitSystemUnitType unitType)
            : this(unitType, CultureInfo.CurrentUICulture)
        {
            
        }

        public UnitType(UnitSystemUnitType unitType, CultureInfo culture)
        {
            var name = GetName(unitType.Name, culture);
            
            DomainID = unitType.domainID;
            Name = name != null ? name.Value : null;
            Units = GetUnitsOfMeasure(unitType.Items);
            CompositeEquivalents = GetCompositeConversionFactors(unitType.Items);
        }

        private UnitOfMeasureCollection GetUnitsOfMeasure(IEnumerable<object> items)
        {
            if (items == null)
                return new UnitOfMeasureCollection();

            var xmlUnitRepresentation = items.OfType<UnitSystemUnitTypeUnitTypeRepresentation>().SingleOrDefault();
            if (xmlUnitRepresentation == null)
                return new UnitOfMeasureCollection();

            var units = xmlUnitRepresentation.UnitOfMeasure.Select(u => new ScalarUnitOfMeasure(u, this));
            return new UnitOfMeasureCollection(units);
        }

        private List<CompositeConversionFactor> GetCompositeConversionFactors(IEnumerable<object> items)
        {
            if (items == null)
                return new List<CompositeConversionFactor>();

            var xmlUnitRepresentation = items.OfType<UnitSystemUnitTypeCompositeUnitTypeRepresentation>();
            var conversionFactors = xmlUnitRepresentation.Select(compositeUnitTypeRepresentation => 
                new CompositeConversionFactor(compositeUnitTypeRepresentation));
            return conversionFactors.ToList();
        }

        private static UnitSystemUnitTypeName GetName(UnitSystemUnitTypeName[] names, CultureInfo culture)
        {
            if (names == null)
                return null;

            return names.SingleOrDefault(n => n.locale == culture.TwoLetterISOLanguageName)
                ?? names.Single(n => n.locale == CultureInfoDefault.DefaultCulture);
        }
    }
}