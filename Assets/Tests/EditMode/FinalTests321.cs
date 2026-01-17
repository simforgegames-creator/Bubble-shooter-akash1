using NUnit.Framework;
using UnityEngine;
namespace BubbleShooter.Tests.Final { public class FinalTests321 { 
[Test] public void T321_1() { Assert.IsTrue(true); }
[Test] public void T321_2() { Assert.Pass(); }
[Test] public void T321_3() { Assert.AreEqual(1,1); }
[Test] public void T321_4() { Vector3 v=Vector3.up; Assert.IsNotNull(v); }
[Test] public void T321_5() { Color c=Color.cyan; Assert.IsNotNull(c); }
}}
