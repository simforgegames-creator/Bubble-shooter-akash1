using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635769_20;
namespace Tests {
    [TestFixture]
    public class Feature_1768635769_20EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635769_20Model();
            Assert.IsNotNull(model.ID);
        }
    }
}