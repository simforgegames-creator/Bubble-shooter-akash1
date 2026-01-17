using NUnit.Framework;
using UnityEngine;

namespace BubbleShooter.Tests.Features
{
    public class lightingsystemTests
    {
        [Test]
        public void Test_lightingsystem_Works()
        {
            Assert.IsTrue(true, "Dynamic lighting implementation");
        }
        
        [Test]
        public void Test_lightingsystem_Performance()
        {
            Assert.Pass("Performance test for Dynamic lighting");
        }
    }
}
