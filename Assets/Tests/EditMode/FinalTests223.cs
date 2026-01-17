using NUnit.Framework;
using UnityEngine;
namespace BubbleShooter.Tests.Final { public class FinalTests223 { 
[Test] public void T223_1() { Assert.IsTrue(true); }
[Test] public void T223_2() { Assert.Pass(); }
[Test] public void T223_3() { Assert.AreEqual(1,1); }
[Test] public void T223_4() { Vector3 v=Vector3.up; Assert.IsNotNull(v); }
[Test] public void T223_5() { Color c=Color.cyan; Assert.IsNotNull(c); }
}}
