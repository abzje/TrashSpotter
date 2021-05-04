using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.TrashSpotter
{
    public class Screen : MonoBehaviour
    {
        protected const string OPEN_TRIGGER_TEXT = "Open";
        protected const string CLOSE_TRIGGER_TEXT = "Close";

        [Header ("Animation")]
        [SerializeField] protected Animator animator = null;

        /// <summary>
        /// Méthode apelé lorsque qu'un écran doit s'ouvrir
        /// Lance l'animation d'ouverture si un aniamtor est présent sinon il s'active
        /// </summary>
        public virtual void Open()
        {
            if (animator != null) animator.SetTrigger(OPEN_TRIGGER_TEXT);
            else transform.gameObject.SetActive(true);
        }

        /// <summary>
        /// Méthode apelé lorsque qu'un écran doit se fermer
        /// Lance l'animation de femeture si un aniamtor est présent sinon il se désactive
        /// </summary>
        public virtual void Close()
        {
            if (animator != null) animator.SetTrigger(CLOSE_TRIGGER_TEXT);
            else transform.gameObject.SetActive(false);
        }

        protected virtual void OnDestroy()
        {
            
        }
    }
}
