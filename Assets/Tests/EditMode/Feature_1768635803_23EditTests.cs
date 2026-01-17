using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635803_23;
namespace Tests {
    [TestFixture]
    public class Feature_1768635803_23EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635803_23Model();
            Assert.IsNotNull(model.ID);
        }
    }
}