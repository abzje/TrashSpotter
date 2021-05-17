using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class GiveForestScreen : Screen
    {
        [Header ("Button")]
        [SerializeField] private Button assoHumanButton = null;
        [SerializeField] private Button assoAgricultureButton = null;
        [SerializeField] private Button assoEcologyButton = null;
        [SerializeField] private Button assoIndustryButton = null;
        [SerializeField] private Button assoEnergyButton = null;

        [Header ("Tree")]
        [SerializeField] private Button treeButton = null;

        [Header ("Money")]
        [SerializeField] private Text moneyValueText = null;

        private void Start()
        {
            treeButton.onClick.AddListener(OnClickTree);

            assoHumanButton.onClick.AddListener(OnClickAssoHumanButton);
            assoAgricultureButton.onClick.AddListener(OnClickAssoAgricultureButton);
            assoEcologyButton.onClick.AddListener(OnClickAssoEcologyButton);
            assoIndustryButton.onClick.AddListener(OnClickAssoIndustryButton);
            assoEnergyButton.onClick.AddListener(OnClickAssoEnergyButton);
        }

        private void OnClickTree()
        {
            UIManager.Instance.OpenScreen(UIManager.Instance.smashSeedPopUp);
        }

        #region assos

        private void OnClickAssoHumanButton()
        {
            UIManager.Instance.OpenAssosPopUp(UIManager.Instance.assosPopUp, AssosPopUp.enAssoCategory.Human);
        }

        private void OnClickAssoAgricultureButton()
        {
            UIManager.Instance.OpenAssosPopUp(UIManager.Instance.assosPopUp, AssosPopUp.enAssoCategory.Agriculture);
        }

        private void OnClickAssoEcologyButton()
        {
            UIManager.Instance.OpenAssosPopUp(UIManager.Instance.assosPopUp, AssosPopUp.enAssoCategory.Ecology);
        }

        private void OnClickAssoIndustryButton()
        {
            UIManager.Instance.OpenAssosPopUp(UIManager.Instance.assosPopUp, AssosPopUp.enAssoCategory.Industry);
        }

        private void OnClickAssoEnergyButton()
        {
            UIManager.Instance.OpenAssosPopUp(UIManager.Instance.assosPopUp, AssosPopUp.enAssoCategory.Energy);
        }

        #endregion

        protected override void OnDestroy()
        {
            base.OnDestroy();

            treeButton.onClick.RemoveListener(OnClickTree);

            assoHumanButton.onClick.RemoveListener(OnClickAssoHumanButton);
            assoAgricultureButton.onClick.RemoveListener(OnClickAssoAgricultureButton);
            assoEcologyButton.onClick.RemoveListener(OnClickAssoEcologyButton);
            assoIndustryButton.onClick.RemoveListener(OnClickAssoIndustryButton);
            assoEnergyButton.onClick.RemoveListener(OnClickAssoEnergyButton);

        }
    }
}
