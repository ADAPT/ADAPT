using AgGateway.ADAPT.ApplicationDataModel.Representations;
using NUnit.Framework;

namespace AgGateway.ADAPT.ApplicationDataModelTest
{

    [TestFixture]
    public class NumericRepresentationValueTest
    {
        [Test]
        public void GivenDefaultConstructorWhenCreatedThenValuesAreNull()
        {
            var representationValue = new NumericRepresentationValue();
            Assert.IsNull(representationValue.Representation);
            Assert.IsNull(representationValue.UserProvidedUnitOfMeasure);
            Assert.IsNull(representationValue.Value);
        }
    }
}
