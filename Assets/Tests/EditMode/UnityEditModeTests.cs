using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    /// <summary>
    /// Example EditMode test for Unity.
    /// EditMode tests run in the Unity Editor and can test logic without entering Play mode.
    /// </summary>
    public class EditModeTests
    {
        [Test]
        public void EditModeTestSimplePasses()
        {
            // Arrange
            int expected = 5;
            int actual = 2 + 3;
            
            // Act & Assert
            Assert.AreEqual(expected, actual, "2 + 3 should equal 5");
        }

        [Test]
        public void TestVector3Operations()
        {
            // Arrange
            Vector3 a = new Vector3(1, 2, 3);
            Vector3 b = new Vector3(4, 5, 6);
            
            // Act
            Vector3 sum = a + b;
            Vector3 expectedSum = new Vector3(5, 7, 9);
            
            // Assert
            Assert.AreEqual(expectedSum, sum, "Vector addition should work correctly");
        }

        [Test]
        public void TestGameObjectCreation()
        {
            // Arrange & Act
            var gameObject = new GameObject("TestObject");
            
            // Assert
            Assert.IsNotNull(gameObject, "GameObject should be created");
            Assert.AreEqual("TestObject", gameObject.name, "GameObject should have correct name");
            Assert.IsNotNull(gameObject.transform, "GameObject should have Transform component");
            
            // Cleanup
            Object.DestroyImmediate(gameObject);
        }

        [Test]
        public void TestComponentAddition()
        {
            // Arrange
            var gameObject = new GameObject("TestObject");
            
            // Act
            var rigidbody = gameObject.AddComponent<Rigidbody>();
            
            // Assert
            Assert.IsNotNull(rigidbody, "Rigidbody component should be added");
            Assert.AreSame(rigidbody, gameObject.GetComponent<Rigidbody>(), 
                "GetComponent should return the same Rigidbody");
            
            // Cleanup
            Object.DestroyImmediate(gameObject);
        }

        [Test]
        public void TestQuaternionOperations()
        {
            // Arrange
            Quaternion identity = Quaternion.identity;
            
            // Act
            Vector3 rotatedVector = identity * Vector3.forward;
            
            // Assert
            Assert.AreEqual(Vector3.forward, rotatedVector, 
                "Identity quaternion should not change vector");
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(1, 2, 3)]
        [TestCase(-5, 10, -15)]
        public void TestVector3Magnitude(float x, float y, float z)
        {
            // Arrange
            Vector3 vector = new Vector3(x, y, z);
            
            // Act
            float magnitude = vector.magnitude;
            float expectedMagnitude = Mathf.Sqrt(x * x + y * y + z * z);
            
            // Assert
            Assert.AreEqual(expectedMagnitude, magnitude, 0.0001f, 
                $"Magnitude of ({x}, {y}, {z}) should be {expectedMagnitude}");
        }
    }
}
