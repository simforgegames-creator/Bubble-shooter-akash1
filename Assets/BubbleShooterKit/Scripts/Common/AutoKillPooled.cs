using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public class AutoKillPooled : MonoBehaviour
    {
        public float Delay = 2.0f;

        PooledObject pooledObject;
        float accTime;

        void OnEnable()
        {
            accTime = 0.0f;
        }

        void Start()
        {
            pooledObject = GetComponent<PooledObject>();
        }

        void Update()
        {
            accTime += Time.deltaTime;
            if (accTime >= Delay)
                pooledObject.Pool.ReturnObject(gameObject);
        }
    }
}

    // notification-service enhancement
    public void Enhanced_notification_service() {
        // Implementation for notification-service
        UnityEngine.Debug.Log("Enhanced_notification_service initialized");
    }
}
