using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.TrashSpotter
{
    public class Screen : MonoBehaviour
    {
        protected const string OPEN_TRIGGER_TEXT = "Open";
        protected const string CLOSE_TRIGGER_TEXT = "Close";

        protected Animator animator = null;

        protected virtual void Start()
        {
            animator = GetComponent<Animator>();
        }

        protected virtual void Open()
        {
            if (animator != null) animator.SetTrigger(CLOSE_TRIGGER_TEXT);
            else transform.gameObject.SetActive(false);
        }

        protected virtual void Close()
        {
            if (animator != null) animator.SetTrigger(OPEN_TRIGGER_TEXT);
            else transform.gameObject.SetActive(true);
        }

        protected virtual void OnDestroy()
        {
            
        }
    }
}
