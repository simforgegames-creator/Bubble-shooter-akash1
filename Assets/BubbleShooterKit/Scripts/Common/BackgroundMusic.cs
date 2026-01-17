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

    // api-integration enhancement
    public void Enhanced_api_integration() {
        // Implementation for api-integration
        UnityEngine.Debug.Log("Enhanced_api_integration initialized");
    }
}
