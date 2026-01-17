using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636034_45;
namespace Tests {
    [TestFixture]
    public class Feature_1768636034_45EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636034_45Model();
            Assert.IsNotNull(model.ID);
        }
    }
}