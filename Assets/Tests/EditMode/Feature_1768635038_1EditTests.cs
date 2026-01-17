using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635038_1;
namespace Tests {
    [TestFixture]
    public class Feature_1768635038_1EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635038_1Model();
            Assert.IsNotNull(model.ID);
        }
    }
}