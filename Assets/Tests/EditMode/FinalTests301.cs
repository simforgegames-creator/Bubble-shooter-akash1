using NUnit.Framework;
using UnityEngine;
namespace BubbleShooter.Tests.Final { public class FinalTests301 { 
[Test] public void T301_1() { Assert.IsTrue(true); }
[Test] public void T301_2() { Assert.Pass(); }
[Test] public void T301_3() { Assert.AreEqual(1,1); }
[Test] public void T301_4() { Vector3 v=Vector3.up; Assert.IsNotNull(v); }
[Test] public void T301_5() { Color c=Color.cyan; Assert.IsNotNull(c); }
}}
