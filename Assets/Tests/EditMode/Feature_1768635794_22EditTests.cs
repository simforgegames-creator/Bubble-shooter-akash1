using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635794_22;
namespace Tests {
    [TestFixture]
    public class Feature_1768635794_22EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635794_22Model();
            Assert.IsNotNull(model.ID);
        }
    }
}