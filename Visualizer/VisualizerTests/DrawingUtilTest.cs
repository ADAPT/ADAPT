using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AgGateway.ADAPT.Visualizer;
using NUnit.Framework;
using Point = AgGateway.ADAPT.ApplicationDataModel.Shapes.Point;

namespace VisualizerTests
{
    [TestFixture]
    public class DrawingUtilTest
    {
        private DrawingUtil _drawingUtil;
        private Graphics _graphics;
        private TabPage _tabPage;

        [SetUp]
        public void Setup()
        {
            _tabPage = new TabPage();
            _graphics = _tabPage.CreateGraphics();
            _drawingUtil = new DrawingUtil(1050, 1050, _graphics);
        }

        [Test]
        public void GivenListOfPointsWhenSetMinAndMaxThenMinIsSet()
        {
            var points = new List<Point>();
            points.Add(new Point { X = 5600, Y = 8900});
            points.Add(new Point { X = 3600, Y = 7200 });
            points.Add(new Point { X = 9900, Y = 1000 });
            points.Add(new Point { X = 7600, Y = 2200 });
            points.Add(new Point { X = 2000, Y = 9000 });

            _drawingUtil.SetMinMax(points);
            Assert.AreEqual(_drawingUtil.MinX, 2000.0);
            Assert.AreEqual(_drawingUtil.MinY, 1000.0);
            Assert.AreEqual(_drawingUtil.MaxX, 9900.0);
            Assert.AreEqual(_drawingUtil.MaxY, 9000.0);
        }

        [Test]
        public void GivenMinAndMaxesSetAndWidthAndHeightAreEqualWhenGetDeltaThenDeltaIsReturned()
        {
            var points = new List<Point>();
            points.Add(new Point { X = 5600, Y = 8900 });
            points.Add(new Point { X = 3600, Y = 7200 });
            points.Add(new Point { X = 9900, Y = 1000 });
            points.Add(new Point { X = 7600, Y = 2200 });
            points.Add(new Point { X = 2000, Y = 9000 });
            _drawingUtil.SetMinMax(points);

            var delta = _drawingUtil.GetDelta();
            Assert.AreEqual(8, delta);
        }

        [Test]
        public void GivenMinAndMaxesSetAndHeightAndLatisGreaterWhenGetDeltaThenDeltaIsReturned()
        {
            _drawingUtil = new DrawingUtil(1050, 1650, _graphics);

            var points = new List<Point>();
            points.Add(new Point { X = 5600, Y = 8900 });
            points.Add(new Point { X = 3600, Y = 7200 });
            points.Add(new Point { X = 9000, Y = 1000 });
            points.Add(new Point { X = 7600, Y = 2200 });
            points.Add(new Point { X = 3000, Y = 9000 });
            _drawingUtil.SetMinMax(points);

            var delta = _drawingUtil.GetDelta();
            Assert.AreEqual(6, delta);
        }

        [Test]
        public void GivenMinAndMaxesSetAndHeightAndLonAreGreaterWhenGetDeltaThenDeltaIsReturned()
        {
            _drawingUtil = new DrawingUtil(600, 1050, _graphics);

            var points = new List<Point>();
            points.Add(new Point { X = 5600, Y = 9000 });
            points.Add(new Point { X = 3600, Y = 7200 });
            points.Add(new Point { X = 9000, Y = 2000 });
            points.Add(new Point { X = 7600, Y = 2700 });
            points.Add(new Point { X = 1000, Y = 8000 });
            _drawingUtil.SetMinMax(points);

            var delta = _drawingUtil.GetDelta();
            Assert.AreEqual(7, delta);
        }

        [TearDown]
        public void TearDown()
        {
            _tabPage.Dispose();
            _graphics.Dispose();
        }
    }
}
