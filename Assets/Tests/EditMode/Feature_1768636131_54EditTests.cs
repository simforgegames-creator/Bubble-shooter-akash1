using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636131_54;
namespace Tests {
    [TestFixture]
    public class Feature_1768636131_54EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636131_54Model();
            Assert.IsNotNull(model.ID);
        }
    }
}