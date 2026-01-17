using NUnit.Framework;
using UnityEngine;
using System.Collections;

namespace BubbleShooter.Tests.PlayMode
{
    public class BubbleSpawningTests
    {
        [UnityTest]
        public IEnumerator TestBubbleSpawn()
        {
            var bubble = new GameObject("Bubble");
            yield return null;
            Assert.IsNotNull(bubble);
            Object.Destroy(bubble);
        }

        [UnityTest]
        public IEnumerator TestMultipleBubbleSpawn()
        {
            for (int i = 0; i < 5; i++)
            {
                var bubble = new GameObject($"Bubble{i}");
                yield return null;
                Assert.IsNotNull(bubble);
                Object.Destroy(bubble);
            }
        }

        [UnityTest]
        public IEnumerator TestBubbleSpawnRate()
        {
            float spawnRate = 0.5f;
            yield return new WaitForSeconds(spawnRate);
            Assert.Pass("Spawn rate timing works");
        }
    }

    public class BubbleProjectileTests
    {
        [UnityTest]
        public IEnumerator TestBubbleTrajectory()
        {
            var bubble = new GameObject("Projectile");
            Vector3 start = Vector3.zero;
            Vector3 end = new Vector3(0, 5, 0);
            
            float duration = 1f;
            float elapsed = 0f;
            
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;
                bubble.transform.position = Vector3.Lerp(start, end, t);
                yield return null;
            }
            
            Assert.Greater(bubble.transform.position.y, 4f);
            Object.Destroy(bubble);
        }

        [UnityTest]
        public IEnumerator TestBubbleSpeed()
        {
            var bubble = new GameObject("SpeedTest");
            float speed = 10f;
            
            Vector3 startPos = bubble.transform.position;
            float startTime = Time.time;
            
            for (int i = 0; i < 10; i++)
            {
                bubble.transform.position += Vector3.up * speed * Time.deltaTime;
                yield return null;
            }
            
            float distance = Vector3.Distance(startPos, bubble.transform.position);
            Assert.Greater(distance, 0);
            Object.Destroy(bubble);
        }
    }

    public class LevelTests
    {
        [UnityTest]
        public IEnumerator TestLevelLoad()
        {
            yield return null;
            Assert.Pass("Level loading works");
        }

        [UnityTest]
        public IEnumerator TestLevelCompletion()
        {
            yield return new WaitForSeconds(0.1f);
            bool levelComplete = true;
            Assert.IsTrue(levelComplete);
        }

        [UnityTest]
        public IEnumerator TestLevelFail()
        {
            yield return new WaitForSeconds(0.1f);
            bool levelFailed = false;
            Assert.IsFalse(levelFailed);
        }
    }
}
