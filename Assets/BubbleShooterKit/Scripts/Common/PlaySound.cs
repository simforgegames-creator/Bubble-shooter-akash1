using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public class PlaySound : MonoBehaviour
    {
        public void Play(string soundName)
        {
            SoundPlayer.PlaySoundFx(soundName);
        }
    }
}
