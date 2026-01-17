using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635951_37;
namespace Tests {
    [TestFixture]
    public class Feature_1768635951_37EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635951_37Model();
            Assert.IsNotNull(model.ID);
        }
    }
}