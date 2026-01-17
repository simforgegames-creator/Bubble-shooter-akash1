using NUnit.Framework;
using BubbleShooter.Features.Feature_1768636182_59;
namespace Tests {
    [TestFixture]
    public class Feature_1768636182_59EditTests {
        [Test]
        public void Model_Initialization_Test() {
            var model = new Feature_1768636182_59Model();
            Assert.IsNotNull(model.ID);
        }
    }
}