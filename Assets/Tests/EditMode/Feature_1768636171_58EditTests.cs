using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636171_58;
namespace Tests {
    [TestFixture]
    public class Feature_1768636171_58EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636171_58Model();
            Assert.IsNotNull(model.ID);
        }
    }
}