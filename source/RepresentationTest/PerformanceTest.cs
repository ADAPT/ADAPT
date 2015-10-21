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
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.Representation.UnitSystem;
using AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods;
using NUnit.Framework;
using UnitOfMeasure = AgGateway.ADAPT.Representation.UnitSystem.UnitOfMeasure;

namespace AgGateway.ADAPT.RepresentationTest
{
    [TestFixture]
    public class PerformanceTest
    {
        [Test]
        public void TestStuff()
        {
            Console.WriteLine("CDF");
            TimeWork(DoWorkRawCDF);
        }

        private static void TimeWork(Action<int> work)
        {
            var totalTime = 0.0;
            var minTime = double.MaxValue;
            var minIndex = -1;
            var maxTime = double.MinValue;
            var maxIndex = -1;

            var longRunCount = 0;


            for (var i = 0; i < 2500000; i++)
            {
                var start = DateTime.Now;
                work(i);
                var end = DateTime.Now;

                var span = end.Subtract(start);
                var millies = span.TotalMilliseconds;

                totalTime += millies;

                if (minTime > millies)
                {
                    minTime = millies;
                    minIndex = i;
                }

                if (maxTime < millies)
                {
                    maxTime = millies;
                    maxIndex = i;
                }

                if (millies >= 1)
                {
                    longRunCount++;
                }
            }

            Console.WriteLine("Total Time: " + totalTime);
            Console.WriteLine("Min Time: " + minTime + " Index: " + minIndex);
            Console.WriteLine("Max Time: " + maxTime + " Index: " + maxIndex);
            Console.WriteLine("Long Run Count: " + longRunCount);
        }

        private static void DoWorkRawCDF(int i)
        {
            var v = new VariableValue(59, "mm", i);

            var result = ConvertCdf(v, "m");
            var a = result.Value;
        }

        public static VariableValue ConvertCdf(VariableValue variableValue, string targetUnit)
        {
            if (variableValue.UnitOfMeasure == targetUnit)
            {
                return variableValue;
            }

            var sourceUnitOfMeasure = GetUomCdf(variableValue.UnitOfMeasure);
            var targetUnitOfMeasure = GetUomCdf(targetUnit);
            var bn = new NumericalValue(sourceUnitOfMeasure.ToModelUom(), variableValue.Value);
            bn.ConvertToUnit(targetUnitOfMeasure);
            var convertedValue = bn.Value;
            return new VariableValue(variableValue.Representation, targetUnit, convertedValue);
        }

        private static UnitOfMeasure GetUomCdf(string uomKey)
        {
            return UnitSystemManager.Instance.UnitOfMeasures[uomKey];
        }
    }

    public class VariableValue
    {
        public double Value { get; private set; }
        public string UnitOfMeasure { get; private set; }
        public int Representation { get; private set; }

        public VariableValue(int representationDomainTag, string unitOfMeasureDomainId, double value)
        {
            Value = value;
            UnitOfMeasure = unitOfMeasureDomainId;
            Representation = representationDomainTag;
        }

        public VariableValue WithValue(double newValue)
        {
            return new VariableValue(Representation, UnitOfMeasure, newValue);
        }

        public string ToString(bool appendUnitsLabel, bool padSpaces)
        {
            return appendUnitsLabel ?
                string.Format("{0} {1}", Value, UnitOfMeasure) :
                string.Format("{0}", Value);
        }

        public override string ToString()
        {
            return ToString(true, false);
        }

        protected bool Equals(VariableValue other)
        {
            return Value.Equals(other.Value) && string.Equals(UnitOfMeasure, other.UnitOfMeasure) && Representation == other.Representation;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((VariableValue)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Value.GetHashCode();
                hashCode = (hashCode * 397) ^ UnitOfMeasure.GetHashCode();
                hashCode = (hashCode * 397) ^ Representation;
                return hashCode;
            }
        }
    }
}
