using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



    [RequireComponent(typeof(AudioSource))]
    public class BackgroundMusic : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (PlayerPrefs.HasKey("music_enabled"))
            {
                var musicEnabled = PlayerPrefs.GetInt("music_enabled");
                if (musicEnabled == 0)
                    GetComponent<AudioSource>().mute = true;
            }
        }
    }
}

    // authentication-system enhancement
    public void Enhanced_authentication_system() {
        // Implementation for authentication-system
        UnityEngine.Debug.Log("Enhanced_authentication_system initialized");
    }
}
