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
                var meters = GetWorkingData(operationData);

                CreateColumns(meters);

                foreach (var spatialRecord in spatialRecords)
                {
                    CreateRow(meters, spatialRecord);
                }

                UpdateColumnNamesWithUom(meters, spatialRecords);
            }

            return _dataTable;
        }

        private static Dictionary<int, IEnumerable<WorkingData>> GetWorkingData(OperationData operationData)
        {
            var workingDataWithDepth = new Dictionary<int, IEnumerable<WorkingData>>();
            for (var i = 0; i <= operationData.MaxDepth; i++)
            {
                var meters = operationData.GetDeviceElementUses(i).SelectMany(x=> x.GetWorkingDatas()).Where(x => x.Representation != null);

                workingDataWithDepth.Add(i, meters);
            }
            return workingDataWithDepth;
        }

        private void CreateColumns(Dictionary<int, IEnumerable<WorkingData>> workingDataDictionary)
        {
            foreach (var kvp in workingDataDictionary)
            {
                foreach (var workingData in kvp.Value)
                {
                    _dataTable.Columns.Add(GetColumnName(workingData, kvp.Key));
                }
            }
        }

        private void CreateRow(Dictionary<int, IEnumerable<WorkingData>> workingDataDictionary, SpatialRecord spatialRecord)
        {
            var dataRow = _dataTable.NewRow();

            foreach(var key in workingDataDictionary.Keys)
            {
                var depth = key;

                foreach (var workingData in workingDataDictionary[key])
                {
                    if (workingData as NumericWorkingData != null)
                        CreateNumericMeterCell(spatialRecord, workingData, depth, dataRow);

                    if (workingData as EnumeratedWorkingData != null)
                        CreateEnumeratedMeterCell(spatialRecord, workingData, depth, dataRow);
                }
            }

            _dataTable.Rows.Add(dataRow);
        }

        private static void CreateEnumeratedMeterCell(SpatialRecord spatialRecord, WorkingData workingData, int depth, DataRow dataRow)
        {
            var enumeratedValue = spatialRecord.GetMeterValue(workingData) as EnumeratedValue;

            dataRow[GetColumnName(workingData, depth)] = enumeratedValue != null && enumeratedValue.Value != null ? enumeratedValue.Value.Value : "";
        }

        private static void CreateNumericMeterCell(SpatialRecord spatialRecord, WorkingData workingData, int depth, DataRow dataRow)
        {
            var numericRepresentationValue = spatialRecord.GetMeterValue(workingData) as NumericRepresentationValue;
            var value = numericRepresentationValue != null
                ? numericRepresentationValue.Value.Value.ToString(CultureInfo.InvariantCulture)
                : "";

            dataRow[GetColumnName(workingData, depth)] = value;
        }

        private void UpdateColumnNamesWithUom(Dictionary<int, IEnumerable<WorkingData>> workingDatas, List<SpatialRecord> spatialRecords)
        {
            foreach (var kvp in workingDatas)
            {
                foreach (var data in kvp.Value)
                {
                    var data1 = data;
                    var workingDataValues = spatialRecords.Select(x => x.GetMeterValue(data1) as NumericRepresentationValue);
                    var numericRepresentationValues = workingDataValues.Where(x => x != null);
                    var uoms = numericRepresentationValues.Select(x => x.Value.UnitOfMeasure).ToList();
                
                    if (uoms.Any())
                        _dataTable.Columns[GetColumnName(data, kvp.Key)].ColumnName += "-" + uoms.First().Code;
                }
            }
        }

        private static string GetColumnName(WorkingData workingData, int depth)
        {
            return String.Format("{0}-{1}-{2}", workingData.Representation.Code, workingData.Id.ReferenceId, depth);
        }
    }
}