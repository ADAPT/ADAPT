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
using AgGateway.ADAPT.Representation.UnitSystem;

namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public class VariableRepresentation : Representation
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

        public UnitType UnitType { get; private set; }

        public VariableRepresentation(RepresentationSystemRepresentationsVariableRepresentation representation)
            : this(representation, CultureInfo.CurrentUICulture)
        {

        }

        public VariableRepresentation(RepresentationSystemRepresentationsVariableRepresentation representation, CultureInfo culture)
            : base(representation.domainID, representation.domainTag)
        {

            var name = GetName(representation.Name, culture);
            Name = name != null ? name.Value : null;
            Description = name != null ? name.description : null;
            UnitType = FindUnitType(representation);

            _unitOfMeasureDefaults = GetDefaultUnitOfMeasures(representation.Items);
            _unitOfMeasurePreferences = GetUnitOfMeasurePreferences(representation.Items);
        }

        private static UnitType FindUnitType(RepresentationSystemRepresentationsVariableRepresentation representation)
        {
            if (representation.UnitTypeRef == null)
                return null;

            var unitType = representation.UnitTypeRef.unitType;
            if (string.IsNullOrEmpty(unitType))
                return null;

            return UnitSystemManager.Instance.UnitTypes[unitType];
        }

        private static Dictionary<UnitSystem.UnitSystem, UnitCollection<UnitOfMeasurePreference>> GetDefaultUnitOfMeasures(IEnumerable<UnitOfMeasurePreferenceType> items)
        {
            if (items == null)
                return new Dictionary<UnitSystem.UnitSystem, UnitCollection<UnitOfMeasurePreference>>();

            return items
                .OfType<RepresentationSystemRepresentationsVariableRepresentationUnitOfMeasureDefault>()
                .Select(u => new UnitOfMeasurePreference(u))
                .GroupBy(u => u.UnitSystem)
                .ToDictionary(g => g.Key, g => new UnitCollection<UnitOfMeasurePreference>(g));
        }

        private Dictionary<UnitSystem.UnitSystem, UnitCollection<UnitOfMeasurePreference>> GetUnitOfMeasurePreferences(IEnumerable<UnitOfMeasurePreferenceType> items)
        {
            if (items == null)
                return new Dictionary<UnitSystem.UnitSystem, UnitCollection<UnitOfMeasurePreference>>();

            return items
                .OfType<RepresentationSystemRepresentationsVariableRepresentationUnitOfMeasurePreference>()
                .Select(u => new UnitOfMeasurePreference(u))
                .GroupBy(u => u.UnitSystem)
                .ToDictionary(g => g.Key, g => new UnitCollection<UnitOfMeasurePreference>(g));
        }

        private static RepresentationSystemRepresentationsVariableRepresentationName GetName(RepresentationSystemRepresentationsVariableRepresentationName[] names, CultureInfo culture)
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
