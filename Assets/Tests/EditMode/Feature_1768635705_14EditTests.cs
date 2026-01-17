using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635705_14;
namespace Tests {
    [TestFixture]
    public class Feature_1768635705_14EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635705_14Model();
            Assert.IsNotNull(model.ID);
        }
    }
}