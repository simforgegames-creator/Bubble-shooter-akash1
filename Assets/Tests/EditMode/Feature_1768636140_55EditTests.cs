using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636140_55;
namespace Tests {
    [TestFixture]
    public class Feature_1768636140_55EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636140_55Model();
            Assert.IsNotNull(model.ID);
        }
    }
}