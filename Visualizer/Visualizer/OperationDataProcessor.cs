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
            _dataTable.Rows.Clear();
            _dataTable.Columns.Clear();

            var spatialRecords = operationData.GetSpatialRecords();
            var meters = GetSections(operationData).SelectMany(x => x.GetMeters()).Where(x => x.Representation != null).ToList();

            CreateColumns(meters);

            foreach (var spatialRecord in spatialRecords)
            {
                CreateRow(meters, spatialRecord);
            }

            return _dataTable;
        }

        private void CreateColumns(IEnumerable<Meter> meters)
        {
            foreach (var meter in meters)
            {
                _dataTable.Columns.Add(meter.Representation.Code);
            }
        }

        private void CreateRow(IEnumerable<Meter> meters, SpatialRecord spatialRecord)
        {
            var dataRow = _dataTable.NewRow();
            foreach (var meter in meters)
            {
                if (meter as NumericMeter != null)
                    CreateNumericMeterCell(spatialRecord, meter, dataRow);

                if (meter as EnumeratedMeter != null)
                    CreateEnumeratedMeterCell(spatialRecord, meter, dataRow);
            }
            _dataTable.Rows.Add(dataRow);
        }

        private static void CreateEnumeratedMeterCell(SpatialRecord spatialRecord, Meter meter, DataRow dataRow)
        {
            var enumeratedValue = spatialRecord.GetMeterValue(meter) as EnumeratedValue;

            dataRow[meter.Representation.Code] = enumeratedValue != null ? enumeratedValue.Value.Value : "";
        }

        private static void CreateNumericMeterCell(SpatialRecord spatialRecord, Meter meter, DataRow dataRow)
        {
            var numericRepresentationValue = spatialRecord.GetMeterValue(meter) as NumericRepresentationValue;
            var value = numericRepresentationValue != null
                ? numericRepresentationValue.Value.Value.ToString(CultureInfo.InvariantCulture) + " " +
                  numericRepresentationValue.Value.UnitOfMeasure.Code
                : "";

            dataRow[meter.Representation.Code] = value;
        }

        private static IEnumerable<Section> GetSections(OperationData operationData)
        {
            for (var i = 0; i < operationData.MaxDepth; i++)
            {
                foreach (var section in operationData.GetSections(i))
                {
                    yield return section;
                }
            }
        }
    }
}