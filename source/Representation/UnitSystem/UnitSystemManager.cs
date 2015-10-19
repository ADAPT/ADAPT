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

using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public class UnitSystemManager
    {
        private static UnitSystemManager _instance;
        private static readonly object ThreadLock = new object();

        public static UnitSystemManager Instance
        {
            get
            {
                if(_instance == null)
                    lock (ThreadLock)
                    {
                        if (_instance == null)
                            _instance = new UnitSystemManager();
                    }
                return _instance;
            }
        }

        public UnitCollection<UnitType> UnitTypes { get; private set; }

        public UnitOfMeasureCollection UnitOfMeasures { get; private set; }

        public UnitOfMeasureSystemCollection UnitOfMeasureSystems { get; private set; }

        private UnitSystemManager()
        {
            var unitSystem = DeserializeUnitSystem();
            UnitTypes = GetUnitTypes(unitSystem);
            UnitOfMeasures = GetUnitsOfMeasure();
            UnitOfMeasureSystems = GetUnitOfMeasureSystems(unitSystem);
        }

        private UnitOfMeasureSystemCollection GetUnitOfMeasureSystems(Generated.UnitSystem unitSystem)
        {
            var unitOfMeasureSystems = unitSystem.UnitOfMeasureSystems.Select(u => new UnitOfMeasureSystem(u, this));
            return new UnitOfMeasureSystemCollection(unitOfMeasureSystems);
        }

        private UnitCollection<UnitType> GetUnitTypes(Generated.UnitSystem unitSystem)
        {
            var unitTypes = unitSystem.UnitTypes.Select(u => new UnitType(u));
            return new UnitCollection<UnitType>(unitTypes);
        }

        private UnitOfMeasureCollection GetUnitsOfMeasure()
        {
            var unitsOfMeasure = UnitTypes.SelectMany(u => u.Units);
            return new UnitOfMeasureCollection(unitsOfMeasure);
        }

        private Generated.UnitSystem DeserializeUnitSystem()
        {
            var serializer = new XmlSerializer(typeof(Generated.UnitSystem));
            var xmlStringBytes = System.Text.Encoding.UTF8.GetBytes(RepresentationResources.UnitSystem);
            using (var stream = new MemoryStream(xmlStringBytes))
                return (Generated.UnitSystem)serializer.Deserialize(stream);
        }

        public UnitOfMeasure CombineUnitsAsFraction(UnitOfMeasure numerator, UnitOfMeasure denominator)
        {
            var firstComponent = new UnitOfMeasureComponent(numerator, 1);
            var secondComponent = new UnitOfMeasureComponent(denominator, -1);
            var firstDomainId = numerator.DomainID;
            var secondDomainId = denominator.DomainID;
            if (numerator is CompositeUnitOfMeasure)
                firstDomainId = "[" + firstDomainId + "]";
            if (denominator is CompositeUnitOfMeasure)
                secondDomainId = "[" + secondDomainId + "]";
            var newDomainId = firstDomainId + "1" + secondDomainId + "-1";

            return new CompositeUnitOfMeasure(newDomainId, new []{firstComponent, secondComponent});
        }
    }
}
