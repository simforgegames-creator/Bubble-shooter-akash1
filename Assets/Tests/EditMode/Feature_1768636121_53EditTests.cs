using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636121_53;
namespace Tests {
    [TestFixture]
    public class Feature_1768636121_53EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636121_53Model();
            Assert.IsNotNull(model.ID);
        }
    }
}