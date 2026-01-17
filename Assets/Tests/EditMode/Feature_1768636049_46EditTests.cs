using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636049_46;
namespace Tests {
    [TestFixture]
    public class Feature_1768636049_46EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636049_46Model();
            Assert.IsNotNull(model.ID);
        }
    }
}