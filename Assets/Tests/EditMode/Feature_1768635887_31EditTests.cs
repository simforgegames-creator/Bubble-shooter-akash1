using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635887_31;
namespace Tests {
    [TestFixture]
    public class Feature_1768635887_31EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635887_31Model();
            Assert.IsNotNull(model.ID);
        }
    }
}