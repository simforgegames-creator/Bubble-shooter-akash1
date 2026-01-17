using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635030_0;
namespace Tests {
    [TestFixture]
    public class Feature_1768635030_0EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635030_0Model();
            Assert.IsNotNull(model.ID);
        }
    }
}