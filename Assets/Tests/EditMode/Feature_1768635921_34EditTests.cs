using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635921_34;
namespace Tests {
    [TestFixture]
    public class Feature_1768635921_34EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635921_34Model();
            Assert.IsNotNull(model.ID);
        }
    }
}