using UnityEngine;

namespace Com.TrashSpotter
{
    public class Screen : MonoBehaviour
    {
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

        }

        /// <summary>
        /// Method called when a screen should be closed
        /// Start the close animation
        /// </summary>
        public virtual void Close()
        {
        }

        protected virtual void OnDestroy()
        {
            
        }
    }
}
