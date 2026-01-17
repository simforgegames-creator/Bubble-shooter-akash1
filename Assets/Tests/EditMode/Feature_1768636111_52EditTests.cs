using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636111_52;
namespace Tests {
    [TestFixture]
    public class Feature_1768636111_52EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636111_52Model();
            Assert.IsNotNull(model.ID);
        }
    }
}