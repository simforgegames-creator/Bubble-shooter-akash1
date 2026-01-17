using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635056_3;
namespace Tests {
    [TestFixture]
    public class Feature_1768635056_3EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635056_3Model();
            Assert.IsNotNull(model.ID);
        }
    }
}