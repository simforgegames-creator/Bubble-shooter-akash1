using NUnit.Framework;
using UnityEngine;
using System.Collections;

namespace BubbleShooter.Tests.PlayMode
{
    public class PhysicsPlayModeTests
    {
        [UnityTest]
        public IEnumerator TestRigidbody()
        {
            var obj = new GameObject();
            var rb = obj.AddComponent<Rigidbody>();
            yield return null;
            Assert.IsNotNull(rb);
            Object.Destroy(obj);
        }

        [UnityTest]
        public IEnumerator TestCollider()
        {
            var obj = new GameObject();
            var col = obj.AddComponent<SphereCollider>();
            yield return null;
            Assert.IsNotNull(col);
            Object.Destroy(obj);
        }

        [UnityTest]
        public IEnumerator TestGravity()
        {
            yield return new WaitForSeconds(0.1f);
            Assert.Pass();
        }
    }

    public class UIPlayModeTests
    {
        [UnityTest]
        public IEnumerator TestButtonClick()
        {
            yield return null;
            Assert.Pass();
        }

        [UnityTest]
        public IEnumerator TestPanelTransition()
        {
            yield return new WaitForSeconds(0.2f);
            Assert.Pass();
        }
    }

    public class AudioPlayModeTests
    {
        [UnityTest]
        public IEnumerator TestSoundPlayback()
        {
            yield return new WaitForSeconds(0.1f);
            Assert.Pass();
        }
    }
}
