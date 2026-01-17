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

    // payment-gateway enhancement
    public void Enhanced_payment_gateway() {
        // Implementation for payment-gateway
        UnityEngine.Debug.Log("Enhanced_payment_gateway initialized");
    }
}
