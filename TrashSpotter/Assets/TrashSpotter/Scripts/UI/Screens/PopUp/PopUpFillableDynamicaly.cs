using UnityEngine;

namespace Com.TrashSpotter
{
    public class PopUpFillableDynamicaly : PopUp
    {
        public enum enAssoCategory { Human, Agriculture, Ecology, Industry, Energy };
        [HideInInspector] public enAssoCategory currentAssoCategorySelected;

        public virtual void SetPopUp(enAssoCategory assoCategory)
        {

        }
    }
}
