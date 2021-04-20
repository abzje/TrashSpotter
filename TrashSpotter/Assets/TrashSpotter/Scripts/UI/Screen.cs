using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.TrashSpotter
{
    public class Screen : MonoBehaviour
    {
        [Header("Animations")]
        [SerializeField] protected Animator animator = null;
        [SerializeField] protected const string OpenTrigger = "Open";
        [SerializeField] protected const string CloseTrigger = "Close";

        protected virtual void Open()
        {
            if (animator != null) animator.SetTrigger(CloseTrigger);
            else transform.gameObject.SetActive(false);
        }

        protected virtual void Close()
        {
            if (animator != null) animator.SetTrigger(OpenTrigger);
            else transform.gameObject.SetActive(true);
        }
    }
}
