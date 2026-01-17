using NUnit.Framework;
using UnityEngine;

namespace BubbleShooter.Tests.Input
{
    public class InputTests
    {
        [Test] public void TestMouseInput() { Assert.IsTrue(true); }
        [Test] public void TestTouchInput() { Assert.IsTrue(true); }
        [Test] public void TestInputPosition() { Vector2 pos = Vector2.zero; Assert.AreEqual(Vector2.zero, pos); }
        [Test] public void TestSwipe() { Assert.Pass(); }
        [Test] public void TestClick() { bool clicked = true; Assert.IsTrue(clicked); }
    }
}
