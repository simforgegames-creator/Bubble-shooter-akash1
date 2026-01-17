using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635584_2;
namespace Tests {
    [TestFixture]
    public class Feature_1768635584_2EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635584_2Model();
            Assert.IsNotNull(model.ID);
        }
    }
}