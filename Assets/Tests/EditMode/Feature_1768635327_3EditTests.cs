using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635327_3;
namespace Tests {
    [TestFixture]
    public class Feature_1768635327_3EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635327_3Model();
            Assert.IsNotNull(model.ID);
        }
    }
}