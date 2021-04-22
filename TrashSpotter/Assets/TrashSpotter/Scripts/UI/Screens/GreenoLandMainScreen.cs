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

        protected override void Start()
        {
            base.Start();
            
            statesButton.onClick.AddListener(OnClickStates);
            customisationButton.onClick.AddListener(OnClickCustomisation);
            giveForestButton.onClick.AddListener(OnClickGiveForest);
        }

        private void OnClickStates()
        {
            Debug.Log("states");
        }

        private void OnClickCustomisation()
        {
            Debug.Log("custo");
        }

        private void OnClickGiveForest()
        {
            Debug.Log("forest");
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
