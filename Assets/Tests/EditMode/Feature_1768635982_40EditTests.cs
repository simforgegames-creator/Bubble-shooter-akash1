using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635982_40;
namespace Tests {
    [TestFixture]
    public class Feature_1768635982_40EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635982_40Model();
            Assert.IsNotNull(model.ID);
        }
    }
}