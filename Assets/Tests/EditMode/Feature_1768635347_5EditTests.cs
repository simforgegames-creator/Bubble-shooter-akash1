using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635347_5;
namespace Tests {
    [TestFixture]
    public class Feature_1768635347_5EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635347_5Model();
            Assert.IsNotNull(model.ID);
        }
    }
}