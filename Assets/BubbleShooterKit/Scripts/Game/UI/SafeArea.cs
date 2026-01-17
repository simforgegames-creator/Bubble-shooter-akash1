using UnityEngine;
namespace SimForge.Games.BubbleShooter.Blaze
{
    public class SafeArea : MonoBehaviour
    {
        RectTransform panel;
        Rect lastSafeArea = new Rect(0, 0, 0, 0);
        void Awake()
        {
            panel = GetComponent<RectTransform>();
            Refresh();
        }
        void Update()
        {
            Refresh();
        }
        void Refresh()
        {
            var safeArea = GetSafeArea();
            if (safeArea != lastSafeArea)
            {
                ApplySafeArea(safeArea);
            }
        }
        Rect GetSafeArea()
        {
            return Screen.safeArea;
        }
        void ApplySafeArea(Rect rect)
        {
            lastSafeArea = rect;

            var anchorMin = rect.position;
            var anchorMax = rect.position + rect.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            panel.anchorMin = anchorMin;
            panel.anchorMax = anchorMax;
        }
    }
}