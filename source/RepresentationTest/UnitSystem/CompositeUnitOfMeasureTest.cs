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

using System.Linq;
using AgGateway.ADAPT.Representation.UnitSystem;
using NUnit.Framework;

namespace JohnDeere.RepresentationTest.UnitSystem
{
    [TestFixture]
    public class CompositeUnitOfMeasureTest
    {
        [Test]
        public void GivenSquareUnitsWhenParsedShouldReturnSingleComponentWithPowerOfTwo()
        {
            var result = new CompositeUnitOfMeasure("m2");

            Assert.AreEqual(1, result.Components.Count);
            Assert.AreEqual(2, result.Components.First().Power);
            Assert.AreEqual("m", result.Components.First().DomainID);
        }

        [Test]
        public void GivenUnitWithNegativePowerWhenParsedShouldReturnSingleComponentWithPowerOfNegOne()
        {
            var result = new CompositeUnitOfMeasure("sec-1");

            Assert.AreEqual(1, result.Components.Count);
            Assert.AreEqual(-1, result.Components.First().Power);
            Assert.AreEqual("sec", result.Components.First().DomainID);
        }

        [Test]
        public void GivenCubedUnitWithNegativePowerWhenParsedShouldReturnSingleCompositeComponent()
        {
            var result = new CompositeUnitOfMeasure("[dm3]-1");

            Assert.AreEqual(1, result.Components.Count);

            var compositeComponent = (CompositeUnitOfMeasure) result.Components.First().Unit;
            Assert.AreEqual(3, compositeComponent.Components.First().Power);
            Assert.AreEqual("dm", compositeComponent.Components.First().DomainID);
        }

        [Test]
        public void GivenTwoUnitsWhenParsedShouldReturnTwoComponents()
        {
            var result = new CompositeUnitOfMeasure("bu1ac-1");

            Assert.AreEqual(2, result.Components.Count);

            Assert.AreEqual(1, result.Components.First().Power);
            Assert.AreEqual(-1, result.Components.Last().Power);

            Assert.AreEqual("bu", result.Components.First().DomainID);
            Assert.AreEqual("ac", result.Components.Last().DomainID);
        }

        [Test]
        public void GivenTwoUnitsWithOneSquaredWhenParsedShouldReturnOneSimpleAndOneCompositeComponent()
        {
            var result = new CompositeUnitOfMeasure("bu1[m2]-1");

            Assert.AreEqual(2, result.Components.Count);
            Assert.AreEqual(1, result.Components.First().Power);
            Assert.AreEqual("bu", result.Components.First().DomainID);

            Assert.AreEqual("m2", result.Components.Last().DomainID);
            Assert.AreEqual(-1, result.Components.Last().Power);
        }

        [Test]
        public void GivenComplexCompositeUnitWhenParsedShouldProperlyBreakDownDomainId()
        {
            var result = new CompositeUnitOfMeasure("[[am2]1am1]1[am2]-1");

            Assert.AreEqual("[[am2]1am1]1[am2]-1", result.DomainID);
            Assert.AreEqual("[am2]1am1", result.Components.First().DomainID);
            Assert.AreEqual("am2", result.Components.Last().DomainID);

            var numerator = (CompositeUnitOfMeasure) result.Components.First().Unit;
            Assert.AreEqual("am2", numerator.Components.First().DomainID);
            Assert.AreEqual("am", numerator.Components.Last().DomainID);

            var denominator = (CompositeUnitOfMeasure) result.Components.Last().Unit;
            Assert.AreEqual("am", denominator.Components.First().DomainID);
        }

        [Test]
        public void GivenComplexCompositeUnitWithComplexDenominatorShouldProperlyBreakDownDomainId()
        {
            var result = new CompositeUnitOfMeasure("bale1[[ft2]1yd1]-1");

            Assert.AreEqual("bale", result.Components.First().DomainID);

            Assert.AreEqual("[ft2]1yd1", result.Components.Last().DomainID);

            var denominator = (CompositeUnitOfMeasure) result.Components.Last().Unit;
            Assert.AreEqual("ft2", denominator.Components.First().DomainID);
            Assert.AreEqual("yd", denominator.Components.Last().DomainID);
        }

        [Test]
        public void GivenSquaredCompositeUnitThenLabelShouldPrettyPrint()
        {
            var result = new CompositeUnitOfMeasure("m2").Label;

            Assert.AreEqual("m^2", result);
        }

        [Test]
        public void GivenUnitWithInversePowerThenLabelShouldPrettyPrint()
        {
            var result = new CompositeUnitOfMeasure("ag1[m2]-1").Label;

            Assert.AreEqual("ag/m^2", result);
        }

        [Test]
        public void GivenUnitWithMultipleComponentsOfFirstPowerShouldPrettyPrint()
        {
            var result = new CompositeUnitOfMeasure("ac1ft1").Label;

            Assert.AreEqual("ac ft", result);
        }

        [Test]
        public void GivenUnitWithMultipleCompoundComponentsThenLabelShouldPrettyPrint()
        {
            var result = new CompositeUnitOfMeasure("[[cm2]1am1]1[Em2]-1").Label;

            Assert.AreEqual("cm^2 am/Em^2", result);
        }

        [Test]
        public void GivenDomainIdAndComponentsWhenInjectedThenPropertiesMatch()
        {
            var result = new CompositeUnitOfMeasure("m2", new[] {new UnitOfMeasureComponent(UnitSystemManager.Instance.UnitOfMeasures["m"], 2),});

            Assert.AreEqual(1, result.Components.Count);
            Assert.AreEqual("m", result.Components.First().DomainID);
        }
    }
}
