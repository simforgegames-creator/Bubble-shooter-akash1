using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635604_4;
namespace Tests {
    [TestFixture]
    public class Feature_1768635604_4EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635604_4Model();
            Assert.IsNotNull(model.ID);
        }
    }
}