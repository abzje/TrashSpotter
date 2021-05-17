using UnityEngine;

namespace Com.TrashSpotter
{
    public class NamePopUp : PopUp
    {
        protected CustomisationScreen custoScreen;

        public override void Open()
        {
            base.Open();

            custoScreen = UIManager.Instance.customisationScreen.GetComponent<CustomisationScreen>();
            custoScreen.fadedBackground.SetActive(true);
        }

        public override void Close()
        {
            base.Close();

            custoScreen.fadedBackground.SetActive(false);
        }
    }
}
