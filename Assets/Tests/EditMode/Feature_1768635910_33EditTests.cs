using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635910_33;
namespace Tests {
    [TestFixture]
    public class Feature_1768635910_33EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635910_33Model();
            Assert.IsNotNull(model.ID);
        }
    }
}