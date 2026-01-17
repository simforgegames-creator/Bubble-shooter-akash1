using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635856_28;
namespace Tests {
    [TestFixture]
    public class Feature_1768635856_28EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635856_28Model();
            Assert.IsNotNull(model.ID);
        }
    }
}