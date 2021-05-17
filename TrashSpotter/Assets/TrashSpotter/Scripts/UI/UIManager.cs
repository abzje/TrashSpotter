using UnityEngine;

namespace Com.TrashSpotter
{
    public class UIManager : MonoBehaviour
    {
        [Header ("Screens")]
        [SerializeField] public Screen trashSpotterMainScreen = null;
        [SerializeField] public Screen greenoLandMainScreen = null;
        [SerializeField] public Screen customisationScreen = null;
        [SerializeField] public Screen giveForestMainScreen = null;
        [SerializeField] public Screen assosPopUp = null;
        [SerializeField] public Screen assoDetailsPopUp = null;
        [SerializeField] public Screen statesPopUp = null;
        [SerializeField] public Screen anteNamePopUp = null;
        [SerializeField] public Screen editableNameNamePopUp = null;
        [SerializeField] public Screen animalTotemPopUp = null;
        [SerializeField] public Screen smashSeedPopUp = null;

        [HideInInspector] public Screen currentScreen;

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
        /// Open the new screen by calling his method Open()
        /// </summary>
        /// <param name="screen">The instance of the screen you want to open</param>
        public void SwitchScreen(Screen screen)
        {
            if (currentScreen == screen) return;
            if (currentScreen != null) currentScreen.Close();

            Debug.Log("closed one " + currentScreen);

            OpenScreen(screen);
        }

        public void OpenAssosPopUp(Screen screen, AssosPopUp.enAssoCategory assoCategory)
        {
            if (!screen.isActiveAndEnabled) screen.gameObject.SetActive(true);

            screen.Open();
            screen.GetComponent<AssosPopUp>().SetPopUp(assoCategory);
        }

        public void OpenAssoDetailsPopUp(Screen screen)
        {
            if (!screen.isActiveAndEnabled) screen.gameObject.SetActive(true);

            screen.Open();
            screen.GetComponent<AssoDetailsPopUp>().SetPopUp();
        }

        /// <summary>
        /// Open the given screen and set it to active if it's not already done
        /// Set this as value for currentScreen
        /// </summary>
        /// <param name="screen">The instance of the screen you want to open</param>
        public void OpenScreen(Screen screen)
        {
            if (currentScreen == screen) return;

            Debug.Log(screen);
            if (!screen.isActiveAndEnabled) screen.gameObject.SetActive(true);

            screen.Open();
            currentScreen = screen;
        }

        /// <summary>
        /// Close the the given screen
        /// </summary>
        /// <param name="screen">The instance of the screen you want to close</param>
        public void CloseScreen(Screen screen)
        {
            screen.Close();
        }

        /// <summary>
        /// Close the the given screen
        /// </summary>
        /// <param name="screen">The instance of the screen you want to close</param>
        public void ClosePopUp(Screen screen)
        {
            currentScreen = currentScreen.previousScreen;
            screen.Close();
        }

        private void OnDestroy()
        {
            if (this == instance) instance = null;

        }
    }
}
