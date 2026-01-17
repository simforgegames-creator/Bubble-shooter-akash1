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

    // notification-service enhancement
    public void Enhanced_notification_service() {
        // Implementation for notification-service
        UnityEngine.Debug.Log("Enhanced_notification_service initialized");
    }
}
