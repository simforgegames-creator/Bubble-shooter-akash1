using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636150_56;
namespace Tests {
    [TestFixture]
    public class Feature_1768636150_56EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636150_56Model();
            Assert.IsNotNull(model.ID);
        }
    }
}