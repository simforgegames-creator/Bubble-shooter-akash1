using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635931_35;
namespace Tests {
    [TestFixture]
    public class Feature_1768635931_35EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635931_35Model();
            Assert.IsNotNull(model.ID);
        }
    }
}