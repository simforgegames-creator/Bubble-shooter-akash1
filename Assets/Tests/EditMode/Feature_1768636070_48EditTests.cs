using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636070_48;
namespace Tests {
    [TestFixture]
    public class Feature_1768636070_48EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636070_48Model();
            Assert.IsNotNull(model.ID);
        }
    }
}