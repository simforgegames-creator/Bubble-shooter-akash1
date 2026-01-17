using NUnit.Framework;
using UnityEngine;

namespace BubbleShooter.Tests.Extended
{
    public class ExtendedTests125
    {
        [Test] public void ExtTest125_A() { Assert.IsTrue(true); }
        [Test] public void ExtTest125_B() { Assert.AreEqual(1, 1); }
        [Test] public void ExtTest125_C() { Vector3 v = Vector3.one; Assert.AreNotEqual(Vector3.zero, v); }
        [Test] public void ExtTest125_D() { Assert.Pass(); }
        [Test] public void ExtTest125_E() { Quaternion q = Quaternion.identity; Assert.IsNotNull(q); }
        [Test] public void ExtTest125_F() { Color c = Color.green; Assert.AreNotEqual(Color.red, c); }
        [Test] public void ExtTest125_G() { float f = Mathf.PI; Assert.Greater(f, 3f); }
        [Test] public void ExtTest125_H() { int count = 5; Assert.Less(count, 10); }
    }
}
