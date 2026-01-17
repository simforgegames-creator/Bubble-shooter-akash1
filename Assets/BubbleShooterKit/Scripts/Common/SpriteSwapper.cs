using UnityEngine;
using UnityEngine.UI;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public class SpriteSwapper : MonoBehaviour
    {
        [SerializeField]
        Sprite enabledSprite = null;

        [SerializeField]
        Sprite disabledSprite = null;

        Image image;

        public void Awake()
        {
            image = GetComponent<Image>();
        }

        public void SwapSprite()
        {
            image.sprite = image.sprite == enabledSprite ? disabledSprite : enabledSprite;
        }

        public void SetEnabled(bool spriteEnabled)
        {
            image.sprite = spriteEnabled ? enabledSprite : disabledSprite;
        }
    }
}
