using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635684_12;
namespace Tests {
    [TestFixture]
    public class Feature_1768635684_12EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635684_12Model();
            Assert.IsNotNull(model.ID);
        }
    }
}