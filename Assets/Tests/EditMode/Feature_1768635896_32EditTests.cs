using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635896_32;
namespace Tests {
    [TestFixture]
    public class Feature_1768635896_32EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635896_32Model();
            Assert.IsNotNull(model.ID);
        }
    }
}