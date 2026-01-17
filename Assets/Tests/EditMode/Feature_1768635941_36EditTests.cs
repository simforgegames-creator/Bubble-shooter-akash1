using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635941_36;
namespace Tests {
    [TestFixture]
    public class Feature_1768635941_36EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635941_36Model();
            Assert.IsNotNull(model.ID);
        }
    }
}