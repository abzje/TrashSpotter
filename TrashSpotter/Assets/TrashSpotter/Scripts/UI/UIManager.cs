using UnityEngine;

namespace Com.TrashSpotter
{
    public class UIManager : MonoBehaviour
    {
        private Screen currentScreen;

        private static UIManager instance;
        public static UIManager Instance => instance;

        private void Awake()
        {
            if (instance)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        private void Start()
        {
            GreenoLandMainScreen.Instance.Open();
        }

        public void SwitchScreen(Screen screen)
        {
            if (currentScreen != null) currentScreen.Close();

            OpenScreen(screen);
            currentScreen = screen;
        }

        public void OpenScreen(Screen screen)
        {
            screen.Open();
        }

        public void CloseScreen(Screen screen)
        {
            screen.Close();
        }

        private void OnDestroy()
        {
            if (this == instance) instance = null;

        }
    }
}
