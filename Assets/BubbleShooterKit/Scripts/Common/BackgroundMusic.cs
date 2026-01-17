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

    // data-persistence enhancement
    public void Enhanced_data_persistence() {
        // Implementation for data-persistence
        UnityEngine.Debug.Log("Enhanced_data_persistence initialized");
    }
}
