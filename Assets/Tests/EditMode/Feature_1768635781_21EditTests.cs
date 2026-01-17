using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635781_21;
namespace Tests {
    [TestFixture]
    public class Feature_1768635781_21EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635781_21Model();
            Assert.IsNotNull(model.ID);
        }
    }
}