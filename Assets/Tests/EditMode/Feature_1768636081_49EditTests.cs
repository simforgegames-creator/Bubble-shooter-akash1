using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636081_49;
namespace Tests {
    [TestFixture]
    public class Feature_1768636081_49EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636081_49Model();
            Assert.IsNotNull(model.ID);
        }
    }
}