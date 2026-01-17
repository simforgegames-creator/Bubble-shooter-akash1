using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635846_27;
namespace Tests {
    [TestFixture]
    public class Feature_1768635846_27EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635846_27Model();
            Assert.IsNotNull(model.ID);
        }
    }
}