using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class TopBanner : MonoBehaviour
    {
        [SerializeField] private Button backButton = null;
        [SerializeField] private Button profileButton = null;

        private void Start()
        {
            backButton.onClick.AddListener(OnClickBack);
            profileButton.onClick.AddListener(OnClickProfile);
        }

        private void OnClickBack()
        {
            UIManager.Instance.SwitchScreen(UIManager.Instance.currentScreen.previousScreen);
        }

        private void OnClickProfile()
        {

        }
    }
}
