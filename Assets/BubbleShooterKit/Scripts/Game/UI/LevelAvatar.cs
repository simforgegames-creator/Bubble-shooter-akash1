using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
    public class LevelAvatar : MonoBehaviour
    {
        bool floating;
        float runningTime;

        void Update()
        {
            if (!floating)
                return;

            var deltaHeight = Mathf.Sin(runningTime + Time.deltaTime);
            var newPos = transform.position;
            newPos.y += deltaHeight * 0.002f;
            transform.position = newPos;
            runningTime += Time.deltaTime * 2;
        }

        public void StartFloatingAnimation()
        {
            floating = true;
        }
    }
}
