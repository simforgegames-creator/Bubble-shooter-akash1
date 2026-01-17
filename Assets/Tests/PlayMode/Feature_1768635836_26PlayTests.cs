using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BubbleShooter.Features.Feature_1768635836_26;
namespace Tests {
    public class Feature_1768635836_26PlayTests {
        [UnityTest]
        public IEnumerator Controller_Runs_Test() {
            var go = new GameObject();
            var ctrl = go.AddComponent<Feature_1768635836_26Controller>();
            var view = go.AddComponent<Feature_1768635836_26View>();
            ctrl.Initialize();
            ctrl.Execute();
            yield return null;
            Assert.IsTrue(ctrl.GetMetric() > 0);
        }
    }
}