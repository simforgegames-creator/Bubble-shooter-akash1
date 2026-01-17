using NUnit.Framework;
using UnityEngine;

namespace BubbleShooter.Tests.Utils
{
    public class MathUtilsTests
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(90, 1.5708f)]
        [TestCase(180, 3.14159f)]
        [TestCase(270, 4.71239f)]
        public void TestAngleToRadians(float degrees, float expectedRadians)
        {
            float radians = degrees * Mathf.Deg2Rad;
            Assert.AreEqual(expectedRadians, radians, 0.001f);
        }

        [Test]
        public void TestDistanceCalculation()
        {
            Vector2 a = new Vector2(0, 0);
            Vector2 b = new Vector2(3, 4);
            float distance = Vector2.Distance(a, b);
            Assert.AreEqual(5f, distance, 0.01f);
        }

        [Test]
        public void TestLerpCalculation()
        {
            float start = 0f;
            float end = 10f;
            float t = 0.5f;
            float result = Mathf.Lerp(start, end, t);
            Assert.AreEqual(5f, result);
        }

        [Test]
        public void TestClampValue()
        {
            float value = 15f;
            float clamped = Mathf.Clamp(value, 0f, 10f);
            Assert.AreEqual(10f, clamped);
        }

        [Test]
        public void TestMinMax()
        {
            float min = Mathf.Min(5f, 10f);
            float max = Mathf.Max(5f, 10f);
            Assert.AreEqual(5f, min);
            Assert.AreEqual(10f, max);
        }
    }

    public class CollectionUtilsTests
    {
        [Test]
        public void TestListOperations()
        {
            var list = new System.Collections.Generic.List<int> { 1, 2, 3 };
            Assert.AreEqual(3, list.Count);
            list.Add(4);
            Assert.AreEqual(4, list.Count);
        }

        [Test]
        public void TestArrayCopy()
        {
            int[] source = { 1, 2, 3 };
            int[] dest = new int[3];
            System.Array.Copy(source, dest, 3);
            Assert.AreEqual(source[0], dest[0]);
        }

        [Test]
        public void TestDictionaryOperations()
        {
            var dict = new System.Collections.Generic.Dictionary<string, int>();
            dict["test"] = 42;
            Assert.AreEqual(42, dict["test"]);
        }
    }

    public class RandomUtilsTests
    {
        [Test]
        public void TestRandomRange()
        {
            float random = Random.Range(0f, 1f);
            Assert.GreaterOrEqual(random, 0f);
            Assert.LessOrEqual(random, 1f);
        }

        [Test]
        public void TestRandomIntRange()
        {
            int random = Random.Range(0, 10);
            Assert.GreaterOrEqual(random, 0);
            Assert.Less(random, 10);
        }

        [Test]
        public void TestRandomColor()
        {
            Color randomColor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
            Assert.IsNotNull(randomColor);
        }
    }
}
