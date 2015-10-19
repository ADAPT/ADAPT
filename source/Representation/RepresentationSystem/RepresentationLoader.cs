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
using System.Linq;
using System.Text.RegularExpressions;

namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public class RepresentationLoader
    {
        public Dictionary<int, ApplicationDataModel.Representation> Load(string ddiExportFileContents = null)
        {
            if (ddiExportFileContents == null)
                ddiExportFileContents = RepresentationResources.ddiExport;
            return ParseFile(ddiExportFileContents).ToDictionary(ddiDefinition => ddiDefinition.Id);
        }

        private static IEnumerable<ApplicationDataModel.Representation> ParseFile(string ddiExportFileContents)
        {
            var definitions = new List<string>();
            var isReadingDefnition = false;
            var emptyLineCount = 0;
            var lines = ddiExportFileContents.Split('\n');
            foreach (var line in lines)
            {
                if (line.Contains("DD Entity:"))
                {
                    isReadingDefnition = true;
                    emptyLineCount = 0;
                }
                else if (string.IsNullOrEmpty(line) || line == "\r")
                {
                    emptyLineCount++;
                }

                if (emptyLineCount == 2 && definitions.Any())
                {
                    yield return CreateDefinition(definitions);
                    isReadingDefnition = false;
                    definitions.Clear();
                }
                else if (isReadingDefnition)
                {
                    definitions.Add(line);
                }
            }
        }

        private static ApplicationDataModel.Representation CreateDefinition(List<string> definitionLines)
        {
            var nameId = definitionLines.Single(l => l.StartsWith("DD Entity:"));
            var unit = definitionLines.FirstOrDefault(l => l.StartsWith("Unit:"));
            var definition = definitionLines.Single(l => l.StartsWith("Definition:"));

            return new ApplicationDataModel.VariableRepresentation
            {
                Id = ParseId(nameId),
                Name = ParseName(nameId),
                Description = ParseDefinition(definition),
//                Unit = ParseUnit(unit)
            };
        }

        private static int ParseId(string value)
        {
            var regex = new Regex("\\d+");
            return int.Parse(regex.Matches(value)[0].Value);
        }

        private static string ParseName(string value)
        {
            var regex = new Regex("\\d+");
            var match = regex.Matches(value)[0];

            return value.Substring(match.Index + match.Length + 1);
        }

        private static string ParseDefinition(string value)
        {
            return value.Substring(12).TrimEnd();
        }

        private static string ParseUnit(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            var unitDescriptionLocation = value.IndexOf(" - ");
            if (unitDescriptionLocation == -1)
                unitDescriptionLocation = value.IndexOf(" (");
            return value.Substring(6, unitDescriptionLocation - 6);
        }
    }
}
