using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class AssoDetailsPopUp : PopUp
    {
        [SerializeField] Image assoImage = null;
        [SerializeField] Text assoNameText = null;
        [SerializeField] Text presentationText = null;
        [SerializeField] Text actionsText = null;


        public void SetPopUp(Association assoc)
        {
            assoImage = assoc._Logo;
            assoNameText.text = assoc._Name;
            presentationText.text = assoc._Presentation;
            actionsText.text = assoc._Actions;
        }
    }
}
