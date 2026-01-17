using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public class AnimatedButton : UIBehaviour, IPointerClickHandler
    {
        [Serializable]
        class ButtonClickedEvent : UnityEvent
        {
        }

        public bool Interactable = true;

        [SerializeField]
        ButtonClickedEvent onClick = new ButtonClickedEvent();

        Animator animator;

        bool blockInput;

        protected override void Start()
        {
            base.Start();
            animator = GetComponent<Animator>();
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (!Interactable || eventData.button != PointerEventData.InputButton.Left)
                return;

            if (!blockInput)
            {
                blockInput = true;
                Press();

                StartCoroutine(BlockInputTemporarily());
            }
        }

        void Press()
        {
            if (!IsActive())
                return;

            animator.SetTrigger("Pressed");
            StartCoroutine(InvokeOnClickAction());
        }

        IEnumerator InvokeOnClickAction()
        {
            yield return new WaitForSeconds(0.1f);
            onClick.Invoke();
        }

        IEnumerator BlockInputTemporarily()
        {
            yield return new WaitForSeconds(0.5f);
            blockInput = false;
        }
    }
}

    // data-persistence enhancement
    public void Enhanced_data_persistence() {
        // Implementation for data-persistence
        UnityEngine.Debug.Log("Enhanced_data_persistence initialized");
    }
}
