using UnityEngine;

namespace Com.TrashSpotter
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] public Screen greenoLandMainScreen = null;
        [SerializeField] public Screen customisationScreen = null;
        [SerializeField] public Screen giveForestMainScreen = null;
        [SerializeField] public Screen assosPopUp = null;
        [SerializeField] public Screen assoDetailsPopUp = null;
        [SerializeField] public Screen statesPopUp = null;
        [SerializeField] public Screen prefixNamePopUp = null;
        [SerializeField] public Screen animalTotemPopUp = null;

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
            OpenScreen(greenoLandMainScreen);
        }

        /// <summary>
        /// Close the current screen by calling his method Close()
        /// Open the new screen by calling his method Open() and set this as value for currentScreen
        /// </summary>
        /// <param name="screen">The instance of the screen you want to open</param>
        public void SwitchScreen(Screen screen)
        {
            if (currentScreen != null) currentScreen.Close();

            OpenScreen(screen);
            currentScreen = screen;
        }

        /// <summary>
        /// Open the given screen if it is active or set to active
        /// </summary>
        /// <param name="screen">The instance of the screen you want to open</param>
        public void OpenScreen(Screen screen)
        {
            if (!screen.isActiveAndEnabled) screen.gameObject.SetActive(true);

            screen.Open();
        }

        /// <summary>
        /// Close the the given screen
        /// </summary>
        /// <param name="screen">The instance of the screen you want to close</param>
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
