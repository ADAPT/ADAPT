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
  *    Kelly Nelson - Added IsDefaultRepresentationForDDI
  *******************************************************************************/
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AgGateway.ADAPT.Representation.Generated;
using AgGateway.ADAPT.Representation.UnitSystem;

namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public class NumericRepresentation : Representation
    {
        private readonly Dictionary<UnitSystem.UnitSystem, UnitCollection<UnitOfMeasurePreference>> _unitOfMeasureDefaults;
        private readonly Dictionary<UnitSystem.UnitSystem, UnitCollection<UnitOfMeasurePreference>> _unitOfMeasurePreferences;

        public UnitCollection<UnitOfMeasurePreference> UnitOfMeasureDefaults
        {
            get
            {
                var unitOfMeasureDefaults = _unitOfMeasureDefaults.SelectMany(d => d.Value);
                return new UnitCollection<UnitOfMeasurePreference>(unitOfMeasureDefaults);
            }
        }

        public UnitCollection<UnitOfMeasurePreference> UnitOfMeasurePreferences
        {
            get
            {
                var unitOfMeasurePreferences = _unitOfMeasurePreferences.SelectMany(p => p.Value);
                return new UnitCollection<UnitOfMeasurePreference>(unitOfMeasurePreferences);
            }
        }

        public UnitDimension UnitDimension { get; private set; }

        public NumericRepresentation(RepresentationSystemRepresentationsNumericRepresentation representation)
            : this(representation, CultureInfo.CurrentUICulture)
        {

        }

        public NumericRepresentation(RepresentationSystemRepresentationsNumericRepresentation representation, CultureInfo culture)
            : base(representation.domainID, representation.domainTag)
        {

            var name = GetName(representation.Name, culture);
            Name = name != null ? name.Value : null;
            Description = name != null ? name.description : null;
            UnitDimension = FindUnitDimension(representation);
            if (representation.RelatedDDI != null)
            {
                Ddi = representation.RelatedDDI[0].ddi;
                if (representation.RelatedDDI.Any(d => d.isDefaultRepresentationForDDI))
                {
                    IsDefaultRepresentationForDDI = true;
                }
            }

            _unitOfMeasureDefaults = GetDefaultUnitOfMeasures(representation.Items);
            _unitOfMeasurePreferences = GetUnitOfMeasurePreferences(representation.Items);
        }

        private static UnitDimension FindUnitDimension(RepresentationSystemRepresentationsNumericRepresentation representation)
        {
            if (representation.UnitDimensionRef == null)
                return null;

            var unitDimension = representation.UnitDimensionRef.unitDimension;
            if (string.IsNullOrEmpty(unitDimension))
                return null;

            return InternalUnitSystemManager.Instance.UnitDimensions[unitDimension];
        }

        private static Dictionary<UnitSystem.UnitSystem, UnitCollection<UnitOfMeasurePreference>> GetDefaultUnitOfMeasures(IEnumerable<UnitOfMeasurePreferenceType> items)
        {
            if (items == null)
                return new Dictionary<UnitSystem.UnitSystem, UnitCollection<UnitOfMeasurePreference>>();

            return items
                .OfType<RepresentationSystemRepresentationsNumericRepresentationUnitOfMeasureDefault>()
                .Select(u => new UnitOfMeasurePreference(u))
                .GroupBy(u => u.UnitSystem)
                .ToDictionary(g => g.Key, g => new UnitCollection<UnitOfMeasurePreference>(g));
        }

        private Dictionary<UnitSystem.UnitSystem, UnitCollection<UnitOfMeasurePreference>> GetUnitOfMeasurePreferences(IEnumerable<UnitOfMeasurePreferenceType> items)
        {
            if (items == null)
                return new Dictionary<UnitSystem.UnitSystem, UnitCollection<UnitOfMeasurePreference>>();

            return items
                .OfType<RepresentationSystemRepresentationsNumericRepresentationUnitOfMeasurePreference>()
                .Select(u => new UnitOfMeasurePreference(u))
                .GroupBy(u => u.UnitSystem)
                .ToDictionary(g => g.Key, g => new UnitCollection<UnitOfMeasurePreference>(g));
        }

        private static RepresentationSystemRepresentationsNumericRepresentationName GetName(RepresentationSystemRepresentationsNumericRepresentationName[] names, CultureInfo culture)
        {
            if (names == null)
                return null;

            return names.SingleOrDefault(n => n.locale == culture.TwoLetterISOLanguageName)
                ?? names.Single(n => n.locale == CultureInfoDefault.DefaultCulture);
        }

        public UnitOfMeasure GetDefaultUnitOfMeasure(UnitSystem.UnitSystem unitOfMeasureSystem)
        {
            if (!_unitOfMeasureDefaults.ContainsKey(unitOfMeasureSystem))
                return null;

            var unitOfMeasurePreference = _unitOfMeasureDefaults[unitOfMeasureSystem].FirstOrDefault();
            if (unitOfMeasurePreference == null)
                return null;

            return unitOfMeasurePreference.UnitOfMeasure;
        }
    }
}
