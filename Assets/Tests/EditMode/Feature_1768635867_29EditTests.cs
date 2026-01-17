using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635867_29;
namespace Tests {
    [TestFixture]
    public class Feature_1768635867_29EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635867_29Model();
            Assert.IsNotNull(model.ID);
        }
    }
}