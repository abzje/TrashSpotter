using UnityEngine;

namespace Com.TrashSpotter
{
    public class Screen : MonoBehaviour
    {
        protected const string OPEN_TRIGGER_TEXT = "Open";
        protected const string CLOSE_TRIGGER_TEXT = "Close";

        [Header ("Animation")]
        [SerializeField] protected Animator animator = null;

        [Header ("Navigation Settings")]
        [SerializeField] public Screen previousScreen = null;

        /// <summary>
        /// Method called when a screen should be opened
        /// Start the open animation
        /// </summary>
        public virtual void Open()
        {
            animator.SetTrigger(OPEN_TRIGGER_TEXT);
        }

        /// <summary>
        /// Method called when a screen should be closed
        /// Start the close animation
        /// </summary>
        public virtual void Close()
        {
            animator.SetTrigger(CLOSE_TRIGGER_TEXT);
        }

        protected virtual void OnDestroy()
        {
            
        }
    }
}
