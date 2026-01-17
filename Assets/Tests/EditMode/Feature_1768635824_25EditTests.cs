using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635824_25;
namespace Tests {
    [TestFixture]
    public class Feature_1768635824_25EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635824_25Model();
            Assert.IsNotNull(model.ID);
        }
    }
}