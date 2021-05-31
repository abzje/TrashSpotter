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

        [Header ("Miscellaneous")]
        [SerializeField] private ScoreBanner scoreBanner = null;

        private void Start()
        {
            statesButton.onClick.AddListener(OnClickStates);
            customisationButton.onClick.AddListener(OnClickCustomisation);
            giveForestButton.onClick.AddListener(OnClickGiveForest);
        }

        private void OnClickStates()
        {
            UIManager.Instance.OpenScreen(UIManager.Instance.statesPopUp);
        }

        private void OnClickCustomisation()
        {
            UIManager.Instance.SwitchScreen(UIManager.Instance.customisationScreen);
        }

        private void OnClickGiveForest()
        {
            UIManager.Instance.SwitchScreen(UIManager.Instance.giveForestMainScreen);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            statesButton.onClick.RemoveListener(OnClickStates);
            customisationButton.onClick.RemoveListener(OnClickCustomisation);
            giveForestButton.onClick.RemoveListener(OnClickGiveForest);
        }
    }
}
