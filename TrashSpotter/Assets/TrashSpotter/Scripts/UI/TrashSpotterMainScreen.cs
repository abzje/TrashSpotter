using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class TrashSpotterMainScreen : Screen
    {
        [SerializeField] private Button backButton = null;
        [SerializeField] private Button profileButton = null;
        [SerializeField] private Text screenTitle = null;

        private void Start()
        {
            backButton.onClick.AddListener(OnClickBack);
            profileButton.onClick.AddListener(OnClickProfile);
        }

        private void OnClickBack()
        {
            if (UIManager.Instance.currentScreen is PopUp)
            {
                Debug.Log("popup");
                UIManager.Instance.ClosePopUp(UIManager.Instance.currentScreen);
                return;
            }

            UIManager.Instance.SwitchScreen(UIManager.Instance.currentScreen.previousScreen);
        }

        private void OnClickProfile()
        {

        }
    }
}
