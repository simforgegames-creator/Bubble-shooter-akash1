using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636059_47;
namespace Tests {
    [TestFixture]
    public class Feature_1768636059_47EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636059_47Model();
            Assert.IsNotNull(model.ID);
        }
    }
}