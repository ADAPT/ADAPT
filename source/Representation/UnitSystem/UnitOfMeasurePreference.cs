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
using AgGateway.ADAPT.Representation.Generated;

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public class UnitOfMeasurePreference : IUnit
    {
        public UnitOfMeasurePreference(UnitOfMeasurePreferenceType unitOfMeasurePreference)
        {
            UnitOfMeasure = UnitSystemManager.Instance.UnitOfMeasures[unitOfMeasurePreference.unitOfMeasure];
            MinValue = unitOfMeasurePreference.minValue;
            MaxValue = unitOfMeasurePreference.maxValue;
            DecimalPlaces = unitOfMeasurePreference.@decimal;
            UnitSystem = GetUnitSystem(unitOfMeasurePreference.unitOfMeasureSystem);
        }

        private UnitSystem GetUnitSystem(string unitOfMeasureSystem)
        {
            UnitSystem unitSystem;
            Enum.TryParse(unitOfMeasureSystem, out unitSystem);

            return unitSystem;
        }

        public UnitOfMeasure UnitOfMeasure { get; private set; }
        public double MinValue { get; private set; }
        public double MaxValue { get; private set; }
        public int DecimalPlaces { get; private set; }
        public UnitSystem UnitSystem { get; set; }

        public string DomainID
        {
            get
            {
                return UnitOfMeasure.DomainID;
            }
        }
    }
}
