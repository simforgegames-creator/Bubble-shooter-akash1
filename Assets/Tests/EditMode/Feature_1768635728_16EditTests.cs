using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635728_16;
namespace Tests {
    [TestFixture]
    public class Feature_1768635728_16EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635728_16Model();
            Assert.IsNotNull(model.ID);
        }
    }
}