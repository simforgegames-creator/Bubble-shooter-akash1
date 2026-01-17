using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635146_12;
namespace Tests {
    [TestFixture]
    public class Feature_1768635146_12EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635146_12Model();
            Assert.IsNotNull(model.ID);
        }
    }
}