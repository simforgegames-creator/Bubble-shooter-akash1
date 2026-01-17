using UnityEngine;
using UnityEngine.UI;
namespace SimForge.Games.BubbleShooter.Blaze
{
    public class ScoreStarWidget : MonoBehaviour
    {
        public Image Image;
        public Sprite OnSprite;
        public Sprite OffSprite;
        void Awake()
        {
            Image.sprite = OffSprite;
        }
        public void Activate()
        {
            Image.sprite = OnSprite;
        }
        public void Deactivate()
        {
            Image.sprite = OffSprite;
        }
    }
}
