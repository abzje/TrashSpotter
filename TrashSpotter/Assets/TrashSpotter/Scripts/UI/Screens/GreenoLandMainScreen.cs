using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class GreenoLandMainScreen : Screen
    {

        [Header ("Buttons")]
        [SerializeField] private Button statesButton = null;
        [SerializeField] private Button customisationButton = null;
        [SerializeField] private Button giveForestButton = null;

        private static GreenoLandMainScreen instance;
        public static GreenoLandMainScreen Instance => instance;

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
            statesButton.onClick.AddListener(OnClickStates);
            customisationButton.onClick.AddListener(OnClickCustomisation);
            giveForestButton.onClick.AddListener(OnClickGiveForest);
        }

        private void OnClickStates()
        {
            UIManager.Instance.OpenScreen(StatesScreen.Instance);
        }

        private void OnClickCustomisation()
        {
            UIManager.Instance.SwitchScreen(CustomisationScreen.Instance);
        }

        private void OnClickGiveForest()
        {
            UIManager.Instance.SwitchScreen(GiveForestScreen.Instance);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            statesButton.onClick.RemoveListener(OnClickStates);
            customisationButton.onClick.RemoveListener(OnClickCustomisation);
            giveForestButton.onClick.RemoveListener(OnClickGiveForest);

            if (this == instance) instance = null;
        }
    }
}
