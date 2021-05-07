using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class EditableNamePopUp : NamePopUp
    {
        [SerializeField] private Text warningText = null;

        public override void Open()
        {
            base.Open();

            warningText.text = "Vous êtes/nPas plus de";
        }
    }
}
