using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636091_50;
namespace Tests {
    [TestFixture]
    public class Feature_1768636091_50EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636091_50Model();
            Assert.IsNotNull(model.ID);
        }
    }
}