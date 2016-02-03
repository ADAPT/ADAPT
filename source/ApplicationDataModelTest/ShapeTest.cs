using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using NUnit.Framework;

namespace AgGateway.ADAPT.ApplicationDataModelTest
{
    [TestFixture]
    public class ShapeTest
    {
        [Test]
        public void GivenLinearRingWhenCreatedThenTypeShouldBeLinearRing()
        {
            var shape = new LinearRing();

            Assert.AreEqual(ShapeTypeEnum.LinearRing, shape.Type);
        }

        [Test]
        public void GivenLineStringWhenCreatedThenTypeShouldBeLineString()
        {
            var shape = new LineString();

            Assert.AreEqual(ShapeTypeEnum.LineString, shape.Type);
        }

        [Test]
        public void GivenMultiLineStringWhenCreatedThenTypeShouldBeMultiLineString()
        {
            var shape = new MultiLineString();

            Assert.AreEqual(ShapeTypeEnum.MultiLineString, shape.Type);
        }

        [Test]
        public void GivenMultiPointWhenCreatedThenTypeShouldBeMultiPoint()
        {
            var shape = new MultiPoint();

            Assert.AreEqual(ShapeTypeEnum.MultiPoint, shape.Type);
        }

        [Test]
        public void GivenPointWhenCreatedThenTypeShouldBePoint()
        {
            var shape = new Point();

            Assert.AreEqual(ShapeTypeEnum.Point, shape.Type);
        }

        [Test]
        public void GivenPolygonWhenCreatedThenTypeShouldBePolygon()
        {
            var shape = new Polygon();

            Assert.AreEqual(ShapeTypeEnum.Polygon, shape.Type);
        }

        [Test]
        public void GivenMultiPolygonWhenCreatedThenTypeShouldBeMultiPolygon()
        {
            var shape = new MultiPolygon();

            Assert.AreEqual(ShapeTypeEnum.MultiPolygon, shape.Type);
        }
    }
}
