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
using System.Text;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods;

namespace AgGateway.ADAPT.Representation.UnitSystem.UnitArithmetic
{
   internal class UnitOfMeasureComponentSimplifier
   {
      private readonly IUnitOfMeasureConverter _converter;

      public UnitOfMeasureComponentSimplifier()
         : this(new UnitOfMeasureConverter())
      {
      }

      public UnitOfMeasureComponentSimplifier(IUnitOfMeasureConverter converter)
      {
         _converter = converter;
      }

      public NumericValue Simplify(IEnumerable<UnitOfMeasureComponent> components, double value)
      {
         var finalValue = value;
         var unitOfMeasureComponents = new Dictionary<string, UnitOfMeasureComponent>();
         foreach (var component in components)
         {
            finalValue = SimplifyComponent(component, unitOfMeasureComponents, finalValue);
         }

         var unitOfMeasure = CombineComponents(unitOfMeasureComponents.Values.ToList(), finalValue);
         return unitOfMeasure;
      }

      public NumericRepresentationValue Simplify(NumericRepresentation representation, IEnumerable<UnitOfMeasureComponent> components, double value)
      {
         var finalValue = value;
         var unitOfMeasureComponents = new Dictionary<string, UnitOfMeasureComponent>();
         foreach (var component in components)
         {
            finalValue = SimplifyComponent(component, unitOfMeasureComponents, finalValue);
         }

         var baseNumber = CombineComponents(unitOfMeasureComponents.Values.ToList(), finalValue);
         return new NumericRepresentationValue(representation, baseNumber.UnitOfMeasure, baseNumber);
      }

      protected double SimplifyComponent(UnitOfMeasureComponent component, Dictionary<string, UnitOfMeasureComponent> unitOfMeasureComponents, double finalValue)
      {
         var scalarUnit = (ScalarUnitOfMeasure)component.Unit;
         if (!unitOfMeasureComponents.ContainsKey(scalarUnit.UnitDimension.DomainID))
         {
            unitOfMeasureComponents.Add(scalarUnit.UnitDimension.DomainID, component);
            return finalValue;
         }

         return CombineComponentsOfSameType(component, unitOfMeasureComponents, finalValue, scalarUnit);
      }

      protected double CombineComponentsOfSameType(UnitOfMeasureComponent component, Dictionary<string, UnitOfMeasureComponent> unitOfMeasureComponents, double finalValue, ScalarUnitOfMeasure scalarUnit)
      {
         var existingComponent = unitOfMeasureComponents[scalarUnit.UnitDimension.DomainID];
         var convertedValue = _converter.Convert(component.Unit, existingComponent.Unit, 1);
         var newPower = existingComponent.Power + component.Power;
         if (newPower == 0)
         {
            var testPower = Math.Abs(existingComponent.Power) - 1;
            for (var i = testPower; i > 1; --i)
            {
               convertedValue = _converter.Convert(component.Unit, existingComponent.Unit, convertedValue);
            }
            unitOfMeasureComponents.Remove(scalarUnit.UnitDimension.DomainID);
         }
         else
         {
            unitOfMeasureComponents[scalarUnit.UnitDimension.DomainID] = new UnitOfMeasureComponent(existingComponent.Unit, newPower);
         }

         finalValue = component.Power < 0 ? finalValue / convertedValue : finalValue * convertedValue;
         return finalValue;
      }

      protected NumericValue CombineComponents(List<UnitOfMeasureComponent> components, double value)
      {
         if (!components.Any())
            return new NumericValue(InternalUnitSystemManager.Instance.UnitOfMeasures["ratio"].ToModelUom(), value);

         if (components.Count > 1 || components.First().Power != 1)
         {
            var compositeUnit = BuildNewComposite(components);

            return SimplifyComposite(compositeUnit, value);

         }
         return new NumericValue(components.First().Unit.ToModelUom(), value);
      }

      private CompositeUnitOfMeasure BuildNewComposite(List<UnitOfMeasureComponent> components)
      {
         var stringBuilder = new StringBuilder();
         foreach (var component in components)
            stringBuilder.Append(BuildDomainId(component));

         return new CompositeUnitOfMeasure(stringBuilder.ToString());
      }

      protected string BuildDomainId(UnitOfMeasureComponent component)
      {
         if (component.Power < -1)
            return string.Format("[{0}{1}]-1", component.DomainID, Math.Abs(component.Power));

         var compositeUom = component.Unit as CompositeUnitOfMeasure;
         if (compositeUom != null)
            return string.Format("[{0}]{1}", component.DomainID, component.Power);

         return string.Format("{0}{1}", component.DomainID, component.Power);
      }

      private NumericValue SimplifyComposite(CompositeUnitOfMeasure compositeUnitOfMeasure, double value)
      {
         if (compositeUnitOfMeasure.Components.Count <= 1)
            return new NumericValue(compositeUnitOfMeasure.ToModelUom(), value);
         foreach (var firstComponent in compositeUnitOfMeasure.Components)
         {
            foreach (var secondComponent in compositeUnitOfMeasure.Components)
            {
               if (firstComponent.DomainID == secondComponent.DomainID)
                  continue;
               try
               {
                  var firstDomainId = firstComponent.Power > 1 ? firstComponent.DomainID + firstComponent.Power : firstComponent.DomainID;
                  var secondDomainId = secondComponent.Power > 1 ? secondComponent.DomainID + secondComponent.Power : secondComponent.DomainID;
                  value = _converter.Convert(InternalUnitSystemManager.Instance.UnitOfMeasures[firstDomainId],
                                                                  InternalUnitSystemManager.Instance.UnitOfMeasures[secondDomainId], value);
                  var uomComponents = CombineCompositeComponents(compositeUnitOfMeasure, firstComponent, secondComponent);
                  return Simplify(uomComponents, value);
               }
               catch (InvalidOperationException)
               {
               }
            }
         }
         return new NumericValue(compositeUnitOfMeasure.ToModelUom(), value);
      }

      private static List<UnitOfMeasureComponent> CombineCompositeComponents(CompositeUnitOfMeasure compositeUnitOfMeasure,
          UnitOfMeasureComponent firstComponent, UnitOfMeasureComponent secondComponent)
      {
         var power = CalculateCompositePower(firstComponent.Power, secondComponent.Power);
         var uomComponents = compositeUnitOfMeasure.Components.ToList();
         uomComponents.Remove(firstComponent);
         uomComponents.Remove(secondComponent);
         if (power != 0)
         {
            uomComponents.Add(new UnitOfMeasureComponent(InternalUnitSystemManager.Instance.UnitOfMeasures[secondComponent.DomainID], secondComponent.Power * 2));
         }
         return uomComponents;
      }

      private static int CalculateCompositePower(int firstComponent, int secondComponent)
      {
         firstComponent = firstComponent > 0 ? 1 : -1;
         secondComponent = secondComponent > 0 ? 1 : -1;
         return firstComponent + secondComponent;
      }
   }
}