using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BubbleShooter.Features.Feature_1768636111_52;
namespace Tests {
    public class Feature_1768636111_52PlayTests {
        [UnityTest]
        public IEnumerator Controller_Runs_Test() {
            var go = new GameObject();
            var ctrl = go.AddComponent<Feature_1768636111_52Controller>();
            var view = go.AddComponent<Feature_1768636111_52View>();
            ctrl.Initialize();
            ctrl.Execute();
            yield return null;
            Assert.IsTrue(ctrl.GetMetric() > 0);
        }
    }
}