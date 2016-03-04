/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy - initial implementation
  *******************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.Visualizer
{
    public class OperationDataProcessor
    {
        private DataTable _dataTable;

        public DataTable ProcessOperationData(OperationData operationData)
        {
            _dataTable = new DataTable();

            if (operationData.GetSpatialRecords != null)
            {
                var spatialRecords = operationData.GetSpatialRecords().ToList();
                var meters = GetMeters(operationData);

                CreateColumns(meters);

                foreach (var spatialRecord in spatialRecords)
                {
                    CreateRow(meters, spatialRecord);
                }

                UpdateColumnNamesWithUom(meters, spatialRecords);
            }

            return _dataTable;
        }

        private static Dictionary<int, IEnumerable<Meter>> GetMeters(OperationData operationData)
        {
            var metersWithDepthId = new Dictionary<int, IEnumerable<Meter>>();
            for (var i = 0; i <= operationData.MaxDepth; i++)
            {
                var meters = operationData.GetSections(i).SelectMany(x=> x.GetMeters()).Where(x => x.Representation != null);

                metersWithDepthId.Add(i, meters);
            }
            return metersWithDepthId;
        }

        private void CreateColumns(Dictionary<int, IEnumerable<Meter>> meters)
        {
            foreach (var kvp in meters)
            {
                foreach (var meter in kvp.Value)
                {
                    _dataTable.Columns.Add(GetColumnName(meter, kvp.Key));
                }
            }
        }

        private void CreateRow(Dictionary<int, IEnumerable<Meter>> meters, SpatialRecord spatialRecord)
        {
            var dataRow = _dataTable.NewRow();

            foreach(var key in meters.Keys)
            {
                var depth = key;

                foreach (var meter in meters[key])
                {
                    if (meter as NumericMeter != null)
                        CreateNumericMeterCell(spatialRecord, meter, depth, dataRow);

                    if (meter as EnumeratedMeter != null)
                        CreateEnumeratedMeterCell(spatialRecord, meter, depth, dataRow);
                }
            }

            _dataTable.Rows.Add(dataRow);
        }

        private static void CreateEnumeratedMeterCell(SpatialRecord spatialRecord, Meter meter, int depth, DataRow dataRow)
        {
            var enumeratedValue = spatialRecord.GetMeterValue(meter) as EnumeratedValue;

            dataRow[GetColumnName(meter, depth)] = enumeratedValue != null && enumeratedValue.Value != null ? enumeratedValue.Value.Value : "";
        }

        private static void CreateNumericMeterCell(SpatialRecord spatialRecord, Meter meter, int depth, DataRow dataRow)
        {
            var numericRepresentationValue = spatialRecord.GetMeterValue(meter) as NumericRepresentationValue;
            var value = numericRepresentationValue != null
                ? numericRepresentationValue.Value.Value.ToString(CultureInfo.InvariantCulture)
                : "";

            dataRow[GetColumnName(meter, depth)] = value;
        }

        private void UpdateColumnNamesWithUom(Dictionary<int, IEnumerable<Meter>> meters, List<SpatialRecord> spatialRecords)
        {
            foreach (var kvp in meters)
            {
                foreach (var meter1 in kvp.Value)
                {
                    var meter = meter1;
                    var meterValues = spatialRecords.Select(x => x.GetMeterValue(meter) as NumericRepresentationValue);
                    var numericRepresentationValues = meterValues.Where(x => x != null);
                    var uoms = numericRepresentationValues.Select(x => x.Value.UnitOfMeasure).ToList();
                
                    if (uoms.Any())
                        _dataTable.Columns[GetColumnName(meter, kvp.Key)].ColumnName += "-" + uoms.First().Code;
                }
            }
        }

        private static string GetColumnName(Meter meter, int depth)
        {
            return String.Format("{0}-{1}-{2}", meter.Representation.Code, meter.Id.ReferenceId, depth);
        }
    }
}