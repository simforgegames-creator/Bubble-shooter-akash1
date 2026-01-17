using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests
{
    /// <summary>
    /// Example PlayMode test for Unity.
    /// PlayMode tests run in the Unity player and can test runtime behavior.
    /// </summary>
    public class PlayModeTests
    {
        [Test]
        public void PlayModeTestSimplePasses()
        {
            // Arrange
            var gameObject = new GameObject("TestObject");
            
            // Act
            var component = gameObject.GetComponent<Transform>();
            
            // Assert
            Assert.IsNotNull(component, "GameObject should have a Transform component");
            
            // Cleanup
            Object.Destroy(gameObject);
        }

        [UnityTest]
        public IEnumerator PlayModeTestWithEnumeratorPasses()
        {
            // Arrange
            var gameObject = new GameObject("TestObject");
            var initialPosition = gameObject.transform.position;
            
            // Act
            gameObject.transform.position = new Vector3(1, 2, 3);
            yield return null; // Wait one frame
            
            // Assert
            Assert.AreNotEqual(initialPosition, gameObject.transform.position, 
                "Position should have changed");
            Assert.AreEqual(new Vector3(1, 2, 3), gameObject.transform.position, 
                "Position should be (1, 2, 3)");
            
            // Cleanup
            Object.Destroy(gameObject);
        }

        [UnityTest]
        public IEnumerator TestGameObjectMovement()
        {
            // Arrange
            var gameObject = new GameObject("MovingObject");
            var startPosition = Vector3.zero;
            var endPosition = new Vector3(10, 0, 0);
            gameObject.transform.position = startPosition;
            
            float duration = 1.0f;
            float elapsed = 0f;
            
            // Act - Move object over time
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;
                gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, t);
                yield return null;
            }
            
            // Assert
            Assert.AreEqual(endPosition, gameObject.transform.position, 
                "Object should reach end position");
            
            // Cleanup
            Object.Destroy(gameObject);
        }
    }
}
