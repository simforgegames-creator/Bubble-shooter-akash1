using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635738_17;
namespace Tests {
    [TestFixture]
    public class Feature_1768635738_17EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635738_17Model();
            Assert.IsNotNull(model.ID);
        }
    }
}