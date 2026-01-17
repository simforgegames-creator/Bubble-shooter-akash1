using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636012_43;
namespace Tests {
    [TestFixture]
    public class Feature_1768636012_43EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636012_43Model();
            Assert.IsNotNull(model.ID);
        }
    }
}