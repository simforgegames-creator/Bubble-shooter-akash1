using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635084_6;
namespace Tests {
    [TestFixture]
    public class Feature_1768635084_6EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635084_6Model();
            Assert.IsNotNull(model.ID);
        }
    }
}