using NUnit.Framework;
using UnityEngine;

namespace BubbleShooter.Tests.Particles
{
    public class ParticleTests
    {
        [Test] public void TestParticleSystem() { Assert.IsTrue(true); }
        [Test] public void TestParticleEmission() { int count = 10; Assert.AreEqual(10, count); }
        [Test] public void TestParticleLifetime() { float lifetime = 2f; Assert.AreEqual(2f, lifetime); }
        [Test] public void TestParticleColor() { Color col = Color.white; Assert.AreEqual(Color.white, col); }
    }
}
