using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635719_15;
namespace Tests {
    [TestFixture]
    public class Feature_1768635719_15EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635719_15Model();
            Assert.IsNotNull(model.ID);
        }
    }
}