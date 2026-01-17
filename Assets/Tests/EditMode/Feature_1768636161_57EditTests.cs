using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636161_57;
namespace Tests {
    [TestFixture]
    public class Feature_1768636161_57EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636161_57Model();
            Assert.IsNotNull(model.ID);
        }
    }
}