using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635113_9;
namespace Tests {
    [TestFixture]
    public class Feature_1768635113_9EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635113_9Model();
            Assert.IsNotNull(model.ID);
        }
    }
}