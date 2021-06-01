using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class TrashSpotterMainScreen : Screen
    {
        [SerializeField] private Button backButton = null;
        [SerializeField] private Button profileButton = null;
        [SerializeField] private Text screenTitle = null;

        private void OnClickBack()
        {
            if (UIManager.Instance.currentScreen is PopUp)
            {
                UIManager.Instance.ClosePopUp(UIManager.Instance.currentScreen);
                return;
            }

            UIManager.Instance.SwitchScreen(UIManager.Instance.currentScreen.previousScreen);
        }

        private void OnClickProfile()
        {

        }

        protected override void OnDestroy()
        {
            backButton.onClick.RemoveListener(OnClickBack);
            profileButton.onClick.RemoveListener(OnClickProfile);
        }


        protected virtual void Start()
        {
            backButton.onClick.AddListener(OnClickBack);
            profileButton.onClick.AddListener(OnClickProfile);
        }

    }
}
