using NUnit.Framework;
using BubbleShooter.Features.Feature_1768635634_7;
namespace Tests {
    [TestFixture]
    public class Feature_1768635634_7EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768635634_7Model();
            Assert.IsNotNull(model.ID);
        }
    }
}