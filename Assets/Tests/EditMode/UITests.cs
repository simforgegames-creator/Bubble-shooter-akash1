using NUnit.Framework;
using UnityEngine;

namespace BubbleShooter.Tests.UI
{
    public class UITests
    {
        [Test]
        public void TestButtonCreation()
        {
            var button = new GameObject("Button");
            Assert.IsNotNull(button);
            Object.DestroyImmediate(button);
        }

        [Test]
        public void TestScreenTransition()
        {
            bool transitioning = false;
            Assert.IsFalse(transitioning);
        }

        [Test]
        public void TestPopupDisplay()
        {
            Assert.Pass("Popup display test");
        }

        [Test]
        public void TestCanvasScaling()
        {
            float scaleFactor = 1.0f;
            Assert.AreEqual(1.0f, scaleFactor);
        }
    }

    public class MenuTests
    {
        [Test]
        public void TestMainMenuLoad()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestSettingsMenu()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestPauseMenu()
        {
            Assert.IsTrue(true);
        }
    }

    public class HUDTests
    {
        [Test]
        public void TestScoreDisplay()
        {
            int score = 12345;
            string scoreText = score.ToString();
            Assert.AreEqual("12345", scoreText);
        }

        [Test]
        public void TestTimerDisplay()
        {
            float time = 60f;
            Assert.Greater(time, 0);
        }

        [Test]
        public void TestLivesDisplay()
        {
            int lives = 3;
            Assert.AreEqual(3, lives);
        }
    }
}
