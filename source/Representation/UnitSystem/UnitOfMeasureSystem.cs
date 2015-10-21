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
using System.Collections.Generic;
using System.Linq;
using AgGateway.ADAPT.Representation.Generated;

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public enum UnitSystem
    {
        umsEnglish = 1,
        umsMetric = 2,
        umsImperial = 3
    }

    public class UnitOfMeasureSystem : IUnit
    {
        private readonly UnitCollection<UnitType> _units;
        public List<string> UnitOfMeasureDomainIds;

        public UnitSystem UnitSystem
        {
            get
            {
                UnitSystem unitSystem;
                Enum.TryParse(DomainID, out unitSystem);
                return unitSystem;
            }
        }

        public UnitCollection<UnitType> UnitTypes
        {
            get { return _units; }
        }

        public string DomainID { get; private set; }

        public UnitOfMeasureSystem(UnitSystemUnitOfMeasureSystem unitOfMeasureSystem, UnitSystemManager unitSystemManager)
        {
            DomainID = unitOfMeasureSystem.domainID;
            _units = GetUnitTypes(unitOfMeasureSystem.UnitOfMeasureRef, unitSystemManager);
        }

        private UnitCollection<UnitType> GetUnitTypes(IEnumerable<UnitSystemUnitOfMeasureSystemUnitOfMeasureRef> unitOfMeasureRefs, UnitSystemManager unitSystemManager)
        {
            if (unitOfMeasureRefs == null)
                return new UnitCollection<UnitType>();

            UnitOfMeasureDomainIds = unitOfMeasureRefs.Select(u => u.unitOfMeasureRef).ToList();

            var unitSystemUnitTypesLinq = unitSystemManager.UnitTypes
                .Where(t => t.Units.Any(u => UnitOfMeasureDomainIds.Contains(u.DomainID)));

            return new UnitCollection<UnitType>(unitSystemUnitTypesLinq);
        }
    }
}
