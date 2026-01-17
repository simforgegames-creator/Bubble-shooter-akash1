using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636002_42;
namespace Tests {
    [TestFixture]
    public class Feature_1768636002_42EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636002_42Model();
            Assert.IsNotNull(model.ID);
        }
    }
}