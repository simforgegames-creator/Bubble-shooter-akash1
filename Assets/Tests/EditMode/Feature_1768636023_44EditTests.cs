using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636023_44;
namespace Tests {
    [TestFixture]
    public class Feature_1768636023_44EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636023_44Model();
            Assert.IsNotNull(model.ID);
        }
    }
}