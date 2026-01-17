using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public class AlertPopup : Popup
    {
        [SerializeField]
        TextMeshProUGUI textLabel = null;

        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(textLabel);
        }

        public void OnButtonPressed()
        {
            Close();
        }

        public void OnCloseButtonPressed()
        {
            Close();
        }

        public void SetText(string text)
        {
            textLabel.text = text;
        }
    }
}
