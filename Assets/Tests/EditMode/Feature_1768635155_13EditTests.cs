using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635155_13;
namespace Tests {
    [TestFixture]
    public class Feature_1768635155_13EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635155_13Model();
            Assert.IsNotNull(model.ID);
        }
    }
}