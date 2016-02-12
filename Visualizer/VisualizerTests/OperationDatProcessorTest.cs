using System;
using System.Collections.Generic;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using AgGateway.ADAPT.Representation.RepresentationSystem.ExtensionMethods;
using AgGateway.ADAPT.Representation.UnitSystem;
using AgGateway.ADAPT.Visualizer;
using NUnit.Framework;

namespace VisualizerTests
{
    [TestFixture]
    public class OperationDatProcessorTest
    {
        private OperationDataProcessor _operationDataProcessor;
        private OperationData _operationData;
        private List<SpatialRecord> _spatialRecords;
        private Dictionary<int, List<Section>> _sections;
        private List<Meter> _meters;

        [SetUp]
        public void Setup()
        {
            _meters = new List<Meter>();
            _sections = new Dictionary<int, List<Section>>();
            _spatialRecords = new List<SpatialRecord>();
            _operationData = new OperationData
            {
                GetSpatialRecords = () => _spatialRecords,
                GetSections = x => _sections[x],
                MaxDepth = 0
            };

            _operationDataProcessor = new OperationDataProcessor();

        }

        [Test]
        public void GivenOperationDataWhenProcessOperationDataThenColumnsAreAdded()
        {
            _meters.Add(new NumericMeter {Representation = RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation()});
            _sections.Add(0, new List<Section>
            {
                new Section
                {
                    Depth = 0,
                    GetMeters = () => _meters,
                }
            });
            _spatialRecords.Add(new SpatialRecord());

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            Assert.AreEqual(1, dataTable.Columns.Count);
            Assert.AreEqual(_meters.First().Representation.Code + "-" + _meters.First().Id.ReferenceId + "-0", dataTable.Columns[0].ColumnName);
        }

        [Test]
        public void GivenOperationDataWithSpatialRecordDataWithNumericRepValueWhenProcessOperationDAtaThenRowsAreAdded()
        {
            var harvestMoistureMeter = new NumericMeter { Representation = RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation() };
            _meters.Add(harvestMoistureMeter);
            _sections.Add(0, new List<Section>
            {
                new Section
                {
                    Depth = 0,
                    GetMeters = () => _meters,
                }
            });

            var spatialRecord = new SpatialRecord();
            var numericRepresentation = new NumericRepresentationValue(RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation(), UnitSystemManager.GetUnitOfMeasure("prcnt"), new NumericValue(UnitSystemManager.GetUnitOfMeasure("prcnt"), 3.0));

            spatialRecord.SetMeterValue(harvestMoistureMeter, numericRepresentation);

            _spatialRecords.Add(spatialRecord);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            Assert.AreEqual(1, dataTable.Rows.Count);
            Assert.AreEqual(numericRepresentation.Value.Value.ToString(), dataTable.Rows[0][0]);
        }

        [Test]
        public void GivenOperationDataWithSpatialRecordDataWithEnumeratedValueWhenProcessOperationDataThenRowsAreAdded()
        {
            var meter = new EnumeratedMeter { Representation = RepresentationInstanceList.dtRecordingStatus.ToModelRepresentation() };
            _meters.Add(meter);
            _sections.Add(0, new List<Section>
            {
                new Section
                {
                    Depth = 0,
                    GetMeters = () => _meters,
                }
            });

            var spatialRecord = new SpatialRecord();
            var enumeratedValue = new EnumeratedValue{Value = DefinedTypeEnumerationInstanceList.dtiRecordingStatusOn.ToModelEnumMember() };

            spatialRecord.SetMeterValue(meter, enumeratedValue);

            _spatialRecords.Add(spatialRecord);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            Assert.AreEqual(1, dataTable.Rows.Count);
            Assert.AreEqual(enumeratedValue.Value.Value, dataTable.Rows[0][0]);
        }

        [Test]
        public void GivenOperationDataWithSpatialRecordDataWithNumericRepValueWhenProcessOperationDataThenColumnNamesContainUom()
        {
            var harvestMoistureMeter = new NumericMeter { Representation = RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation() };
            _meters.Add(harvestMoistureMeter);
            _sections.Add(0, new List<Section>
            {
                new Section
                {
                    Depth = 0,
                    GetMeters = () => _meters,
                }
            });

            var spatialRecord = new SpatialRecord();
            var numericRepresentation = new NumericRepresentationValue(RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation(), UnitSystemManager.GetUnitOfMeasure("prcnt"), new NumericValue(UnitSystemManager.GetUnitOfMeasure("prcnt"), 3.0));

            spatialRecord.SetMeterValue(harvestMoistureMeter, numericRepresentation);

            _spatialRecords.Add(spatialRecord);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            var expectedColumnName = _meters.First().Representation.Code + "-" + _meters.First().Id.ReferenceId + "-0-" +  numericRepresentation.Value.UnitOfMeasure.Code;
            Assert.AreEqual(expectedColumnName, dataTable.Columns[0].ColumnName);
        }

        [Test]
        public void GivenOperationDataWithMultipleMeterValuesWhenProcessOperationDataThenRowsAreAdded()
        {
            _meters.Add(new NumericMeter { Representation = RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation() });
            _sections.Add(0, new List<Section>
            {
                new Section
                {
                    Depth = 0,
                    GetMeters = () => _meters,
                }
            });

            CreateHavestMoistureSpatialRecord(_meters[0], 3.0);
            CreateHavestMoistureSpatialRecord(_meters[0], 5.0);
            CreateHavestMoistureSpatialRecord(_meters[0], 9.0);
            CreateHavestMoistureSpatialRecord(_meters[0], 2.0);
            CreateHavestMoistureSpatialRecord(_meters[0], 333.0);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            Assert.AreEqual(5, dataTable.Rows.Count);
            Assert.AreEqual("3", dataTable.Rows[0][0]);
            Assert.AreEqual("5", dataTable.Rows[1][0]);
            Assert.AreEqual("9", dataTable.Rows[2][0]);
            Assert.AreEqual("2", dataTable.Rows[3][0]);
            Assert.AreEqual("333", dataTable.Rows[4][0]);
        }

        private void CreateHavestMoistureSpatialRecord(Meter meter, double value)
        {
            var spatialRecord = new SpatialRecord();
            var meter1Value1 = CreateHarvestMoisture(value);
            spatialRecord.SetMeterValue(meter, meter1Value1);
            _spatialRecords.Add(spatialRecord);
        }

        private static NumericRepresentationValue CreateHarvestMoisture(double value)
        {
            return new NumericRepresentationValue(RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation(), UnitSystemManager.GetUnitOfMeasure("prcnt"), new NumericValue(UnitSystemManager.GetUnitOfMeasure("prcnt"), value));
        }
    }
}
