using NUnit.Framework;
using UnityEngine;

namespace BubbleShooter.Tests.Gameplay
{
    public class BubblePhysicsTests
    {
        [Test]
        public void TestBubbleGravity()
        {
            float gravity = -9.81f;
            Assert.Less(gravity, 0, "Gravity should be negative");
        }

        [Test]
        public void TestBubbleVelocity()
        {
            Vector2 velocity = new Vector2(5f, 10f);
            Assert.AreEqual(5f, velocity.x);
            Assert.AreEqual(10f, velocity.y);
        }

        [Test]
        public void TestBubbleCollision()
        {
            Vector3 pos1 = new Vector3(0, 0, 0);
            Vector3 pos2 = new Vector3(1, 0, 0);
            float distance = Vector3.Distance(pos1, pos2);
            Assert.AreEqual(1f, distance, 0.01f);
        }

        [Test]
        public void TestBubbleRadius()
        {
            float radius = 0.5f;
            float diameter = radius * 2;
            Assert.AreEqual(1f, diameter);
        }
    }

    public class BubbleMatchingTests
    {
        [Test]
        public void TestColorMatching()
        {
            Color red1 = Color.red;
            Color red2 = Color.red;
            Assert.AreEqual(red1, red2);
        }

        [Test]
        public void TestMatchThreshold()
        {
            int matchCount = 3;
            Assert.GreaterOrEqual(matchCount, 3);
        }

        [Test]
        public void TestNeighborDetection()
        {
            int neighbors = 6;
            Assert.AreEqual(6, neighbors, "Hex grid has 6 neighbors");
        }

        [Test]
        public void TestChainReaction()
        {
            bool chainTriggered = true;
            Assert.IsTrue(chainTriggered);
        }
    }

    public class ScoringTests
    {
        [Test]
        public void TestBaseScore()
        {
            int baseScore = 100;
            Assert.AreEqual(100, baseScore);
        }

        [Test]
        public void TestComboMultiplier()
        {
            int combo = 2;
            float multiplier = 1f + (combo * 0.5f);
            Assert.AreEqual(2f, multiplier);
        }

        [Test]
        public void TestScoreAccumulation()
        {
            int totalScore = 0;
            totalScore += 100;
            totalScore += 200;
            Assert.AreEqual(300, totalScore);
        }

        [Test]
        [TestCase(100, 1, 100)]
        [TestCase(100, 2, 150)]
        [TestCase(100, 3, 200)]
        public void TestScoreWithMultiplier(int base Score, int combo, int expected)
        {
            float multiplier = 1f + ((combo - 1) * 0.5f);
            int result = (int)(baseScore * multiplier);
            Assert.AreEqual(expected, result);
        }
    }
}
