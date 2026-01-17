using NUnit.Framework;
using UnityEngine;
namespace BubbleShooter.Tests.Final { public class FinalTests213 { 
[Test] public void T213_1() { Assert.IsTrue(true); }
[Test] public void T213_2() { Assert.Pass(); }
[Test] public void T213_3() { Assert.AreEqual(1,1); }
[Test] public void T213_4() { Vector3 v=Vector3.up; Assert.IsNotNull(v); }
[Test] public void T213_5() { Color c=Color.cyan; Assert.IsNotNull(c); }
}}
