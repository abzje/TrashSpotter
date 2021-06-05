using UnityEngine;
using UnityEngine.UI;

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
            custoScreen.fadedBackground.GetComponent<Button>().onClick.AddListener(OnClickQuit);
        }

        private void OnClickQuit()
        {
            UIManager.Instance.ClosePopUp(this);
        }

        public override void Close()
        {
            base.Close();

            custoScreen.fadedBackground.SetActive(false);
            custoScreen.fadedBackground.GetComponent<Button>().onClick.RemoveListener(OnClickQuit);
        }
    }
}
