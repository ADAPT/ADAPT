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
using System.Text;

namespace AgGateway.ADAPT.Representation.UnitSystem
{
    public class CompositeUnitOfMeasure : UnitOfMeasure
    {
        private const char OpenBracketCharacter = '[';
        private const char CloseBracketCharacter = ']';
        private const char NegativeSign = '-';
        private static readonly string CloseBracketString = CloseBracketCharacter.ToString(CultureInfo.InvariantCulture);
        private static readonly string OpenBracketString = OpenBracketCharacter.ToString(CultureInfo.InvariantCulture);
        private static readonly List<char> NumericChars = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        public List<UnitOfMeasureComponent> Components { get; private set; }

        public CompositeUnitOfMeasure(string domainId)
        {
            DomainID = domainId;
            Components = BuildComponents(domainId);
        }

        public CompositeUnitOfMeasure(string domainId, IEnumerable<UnitOfMeasureComponent> components)
        {
            DomainID = domainId;
            Components = new List<UnitOfMeasureComponent>(components);
        }

        public override string Label
        {
            get { return BuildLabel(); }
            protected set {}
        }

        public override string LabelPlural
        {
            get { return BuildLabel(); }
            protected set { }
        }

        private string BuildLabel()
        {
            var label = new StringBuilder();
            foreach (var component in Components)
            {
                if (component.Power < 0)
                    label.Append("/");
                else if (label.Length > 0)
                    label.Append(" ");
                label.Append(component.Unit.Label);
                if (component.Power > 1)
                    label.Append(string.Format("{0}{1}", "^", component.Power));
            }
            return label.ToString();
        }

        private static List<UnitOfMeasureComponent> BuildComponents(string domainId)
        {
            var part = FindPart(domainId);
            var components = new List<UnitOfMeasureComponent>
            {
                BuildComponent(part)
            };

            var remaining = domainId.Substring(part.Length);
            if (!string.IsNullOrEmpty(remaining))
                components.AddRange(BuildComponents(remaining));

            return components;
        }

        private static string FindPart(string domainId)
        {
            var openBracketCount = 0;
            var powerIndex = 0;
            for (var i = 0; i < domainId.Length; i++)
            {
                var character = domainId[i];
                if (character == OpenBracketCharacter)
                    openBracketCount++;

                else if (character == CloseBracketCharacter)
                    openBracketCount--;

                else if (openBracketCount == 0 && IsNumeric(character))
                {
                    powerIndex = i;
                    break;
            }
        }

            return domainId.Substring(0, powerIndex + 1);
        }

        private static UnitOfMeasureComponent BuildComponent(string domainId)
        {
            if (domainId.Contains(OpenBracketString) || domainId.Contains(CloseBracketString))
                return BuildCompositeComponent(domainId);

            return BuildSimpleComponent(domainId);
        }

        private static UnitOfMeasureComponent BuildSimpleComponent(string domainId)
        {
            var power = GetPower(domainId);
            var powerLength = power.ToString(CultureInfo.InvariantCulture).Length;
            var unitOfMeasureDomainId = domainId.Substring(0, domainId.Length - powerLength);
            var unitOfMeasure = InternalUnitSystemManager.Instance.UnitOfMeasures[unitOfMeasureDomainId];
            return new UnitOfMeasureComponent(unitOfMeasure, power);
        }

        private static UnitOfMeasureComponent BuildCompositeComponent(string domainId)
        {
            var power = GetPower(domainId);
            var strippedDomainId = StripDomainId(domainId);
            var composite = new CompositeUnitOfMeasure(strippedDomainId);
            return new UnitOfMeasureComponent(composite, power);
        }

        private static int GetPower(string domainId)
        {
            var multiplier = 1;
            var power = 1;
            var openBracketCount = 0;
            foreach (var character in domainId)
            {
                if (character == OpenBracketCharacter)
                    openBracketCount++;

                else if (character == CloseBracketCharacter)
                    openBracketCount--;

                else if (openBracketCount == 0 && character == NegativeSign)
                    multiplier = -1;

                else if(openBracketCount == 0 && IsNumeric(character))
            {
                    power = int.Parse(character.ToString(CultureInfo.InvariantCulture));
                    break;
                }
            }

            return power * multiplier;
        }

        private static string StripDomainId(string domainId)
        {
            if (!domainId.StartsWith(OpenBracketString))
                return domainId;

            var openBracketCount = 0;
            var closingBracketIndex = 0;
            foreach (var character in domainId)
            {
                if (character == OpenBracketCharacter)
                    openBracketCount++;

                else if (character == CloseBracketCharacter)
                    openBracketCount--;

                if (openBracketCount == 0)
                    break;
                closingBracketIndex++;
        }
            return domainId.Substring(1, closingBracketIndex - 1);
    }

        private static bool IsNumeric(char character)
    {
            return NumericChars.Contains(character);
        }
    }
}
