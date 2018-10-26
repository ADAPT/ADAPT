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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using AgGateway.ADAPT.Representation.Generated;

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public class InternalUnitSystemManager
    {
        private static InternalUnitSystemManager _instance;
        private static readonly object ThreadLock = new object();

        public static InternalUnitSystemManager Instance
        {
            get
            {
                if(_instance == null)
                    lock (ThreadLock)
                    {
                        if (_instance == null)
                            _instance = new InternalUnitSystemManager();
                    }
                return _instance;
            }
        }

        public UnitCollection<UnitDimension> UnitDimensions { get; private set; }

        public Dictionary<string, string> DomainIdToUnRec20Code { get; private set; } 
        public Dictionary<string, string> UnRec20CodeToDomainId { get; private set; } 

        public UnitOfMeasureCollection UnitOfMeasures { get; private set; }

        public UnitOfMeasureSystemCollection UnitOfMeasureSystems { get; private set; }

        private InternalUnitSystemManager()
        {
            var unitSystem = DeserializeUnitSystem();
            UnitDimensions = GetUnitDimensions(unitSystem);
            UnitOfMeasures = GetUnitsOfMeasure();
            UnitOfMeasureSystems = GetUnitOfMeasureSystems(unitSystem);

            var unRec20Codes = DeserializeUnRec20Codes();
            PopulateUnRec20Codes(unRec20Codes);
        }

        private void PopulateUnRec20Codes(Root unRec20Codes)
        {
            DomainIdToUnRec20Code = new Dictionary<string, string>();
            UnRec20CodeToDomainId = new Dictionary<string, string>();

            foreach (var row in unRec20Codes.Rows)
            {
                DomainIdToUnRec20Code.Add(row.DomainId, row.UnRec20);
                UnRec20CodeToDomainId.Add(row.UnRec20, row.DomainId);
            }
        }

        private UnitOfMeasureSystemCollection GetUnitOfMeasureSystems(Generated.UnitSystem unitSystem)
        {
            var unitOfMeasureSystems = unitSystem.UnitOfMeasureSystems.Select(u => new UnitOfMeasureSystem(u, this));
            return new UnitOfMeasureSystemCollection(unitOfMeasureSystems);
        }

        private UnitCollection<UnitDimension> GetUnitDimensions(Generated.UnitSystem unitSystem)
        {
            var unitDimensions = unitSystem.UnitDimensions.Select(u => new UnitDimension(u));
            return new UnitCollection<UnitDimension>(unitDimensions);
        }

        private UnitOfMeasureCollection GetUnitsOfMeasure()
        {
            var unitsOfMeasure = UnitDimensions.SelectMany(u => u.Units);
            return new UnitOfMeasureCollection(unitsOfMeasure);
        }

        private Generated.UnitSystem DeserializeUnitSystem()
        {
            var serializer = new XmlSerializer(typeof(Generated.UnitSystem));

            var xmlStringBytes = File.ReadAllBytes(UnitSystemManager.UnitSystemDataLocation);
            using (var stream = new MemoryStream(xmlStringBytes))
                return (Generated.UnitSystem)serializer.Deserialize(stream);
        }

        private Root DeserializeUnRec20Codes()
        {
            var serializer = new XmlSerializer(typeof (Root));
            var xmlStringBytes = System.Text.Encoding.UTF8.GetBytes(Properties.Resources.DomainIdToUNRec20);
            using (var stream = new MemoryStream(xmlStringBytes))
                return (Root) serializer.Deserialize(stream);
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
