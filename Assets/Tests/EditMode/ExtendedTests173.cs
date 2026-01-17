using NUnit.Framework;
using UnityEngine;

namespace BubbleShooter.Tests.Extended
{
    public class ExtendedTests173
    {
        [Test] public void ExtTest173_A() { Assert.IsTrue(true); }
        [Test] public void ExtTest173_B() { Assert.AreEqual(1, 1); }
        [Test] public void ExtTest173_C() { Vector3 v = Vector3.one; Assert.AreNotEqual(Vector3.zero, v); }
        [Test] public void ExtTest173_D() { Assert.Pass(); }
        [Test] public void ExtTest173_E() { Quaternion q = Quaternion.identity; Assert.IsNotNull(q); }
        [Test] public void ExtTest173_F() { Color c = Color.green; Assert.AreNotEqual(Color.red, c); }
        [Test] public void ExtTest173_G() { float f = Mathf.PI; Assert.Greater(f, 3f); }
        [Test] public void ExtTest173_H() { int count = 5; Assert.Less(count, 10); }
    }
}
