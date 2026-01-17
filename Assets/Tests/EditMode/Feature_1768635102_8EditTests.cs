using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635102_8;
namespace Tests {
    [TestFixture]
    public class Feature_1768635102_8EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635102_8Model();
            Assert.IsNotNull(model.ID);
        }
    }
}