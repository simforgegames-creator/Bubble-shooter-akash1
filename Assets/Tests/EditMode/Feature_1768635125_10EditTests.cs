using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635125_10;
namespace Tests {
    [TestFixture]
    public class Feature_1768635125_10EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635125_10Model();
            Assert.IsNotNull(model.ID);
        }
    }
}