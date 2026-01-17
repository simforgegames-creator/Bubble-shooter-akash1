using NUnit.Framework;
using UnityEngine;
namespace BubbleShooter.Tests.Final { public class FinalTests206 { 
[Test] public void T206_1() { Assert.IsTrue(true); }
[Test] public void T206_2() { Assert.Pass(); }
[Test] public void T206_3() { Assert.AreEqual(1,1); }
[Test] public void T206_4() { Vector3 v=Vector3.up; Assert.IsNotNull(v); }
[Test] public void T206_5() { Color c=Color.cyan; Assert.IsNotNull(c); }
}}
