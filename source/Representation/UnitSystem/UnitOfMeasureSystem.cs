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
        private readonly UnitCollection<UnitDimension> _units;
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

        public UnitCollection<UnitDimension> UnitDimensions
        {
            get { return _units; }
        }

        public string DomainID { get; private set; }

        public UnitOfMeasureSystem(UnitSystemUnitOfMeasureSystem unitOfMeasureSystem, InternalUnitSystemManager unitSystemManager)
        {
            DomainID = unitOfMeasureSystem.domainID;
            _units = GetUnitDimensions(unitOfMeasureSystem.UnitOfMeasureRef, unitSystemManager);
        }

        private UnitCollection<UnitDimension> GetUnitDimensions(IEnumerable<UnitSystemUnitOfMeasureSystemUnitOfMeasureRef> unitOfMeasureRefs, InternalUnitSystemManager unitSystemManager)
        {
            if (unitOfMeasureRefs == null)
                return new UnitCollection<UnitDimension>();

            UnitOfMeasureDomainIds = unitOfMeasureRefs.Select(u => u.unitOfMeasureRef).ToList();

            var dimensions = unitSystemManager.UnitDimensions
                .Where(t => t.Units.Any(u => UnitOfMeasureDomainIds.Contains(u.DomainID)));

            return new UnitCollection<UnitDimension>(dimensions);
        }
    }
}
