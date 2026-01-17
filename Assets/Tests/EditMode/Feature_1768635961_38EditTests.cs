using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635961_38;
namespace Tests {
    [TestFixture]
    public class Feature_1768635961_38EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635961_38Model();
            Assert.IsNotNull(model.ID);
        }
    }
}