using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635758_19;
namespace Tests {
    [TestFixture]
    public class Feature_1768635758_19EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635758_19Model();
            Assert.IsNotNull(model.ID);
        }
    }
}