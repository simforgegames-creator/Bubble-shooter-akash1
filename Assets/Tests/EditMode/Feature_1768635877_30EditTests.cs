using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635877_30;
namespace Tests {
    [TestFixture]
    public class Feature_1768635877_30EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635877_30Model();
            Assert.IsNotNull(model.ID);
        }
    }
}