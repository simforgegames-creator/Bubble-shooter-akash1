using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635972_39;
namespace Tests {
    [TestFixture]
    public class Feature_1768635972_39EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635972_39Model();
            Assert.IsNotNull(model.ID);
        }
    }
}