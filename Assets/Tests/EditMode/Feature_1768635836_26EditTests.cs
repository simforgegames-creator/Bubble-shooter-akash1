using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635836_26;
namespace Tests {
    [TestFixture]
    public class Feature_1768635836_26EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635836_26Model();
            Assert.IsNotNull(model.ID);
        }
    }
}