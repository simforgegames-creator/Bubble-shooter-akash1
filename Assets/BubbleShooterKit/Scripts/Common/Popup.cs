using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public class Popup : MonoBehaviour
	{
		[HideInInspector]
        public BaseScreen ParentScreen;

        public UnityEvent OnOpen;
        public UnityEvent OnClose;

        Animator animator;

        protected virtual void Awake()
        {
            animator = GetComponent<Animator>();
        }

        protected virtual void Start()
        {
            OnOpen.Invoke();
        }

        public void Close()
        {
            OnClose.Invoke();

            if (ParentScreen != null)
                ParentScreen.ClosePopup();

            if (animator != null)
            {
                animator.Play("Close");
                StartCoroutine(DestroyPopup());
            }
            else
            {
                Destroy(gameObject);
            }
        }

	    IEnumerator DestroyPopup()
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
	}
}
