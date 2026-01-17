using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635136_11;
namespace Tests {
    [TestFixture]
    public class Feature_1768635136_11EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635136_11Model();
            Assert.IsNotNull(model.ID);
        }
    }
}