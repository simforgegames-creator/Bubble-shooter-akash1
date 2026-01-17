using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636101_51;
namespace Tests {
    [TestFixture]
    public class Feature_1768636101_51EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636101_51Model();
            Assert.IsNotNull(model.ID);
        }
    }
}