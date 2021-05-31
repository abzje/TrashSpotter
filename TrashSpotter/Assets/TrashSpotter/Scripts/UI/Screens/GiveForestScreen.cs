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

        [Header ("Miscellaneous")]
        [SerializeField] private ScoreBanner scoreBanner = null;
        [SerializeField] private Button treeButton = null;
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
            UIManager.Instance.OpenAssosPopUp(UIManager.Instance.assosPopUp, EAssociationCategory.HUMAN);
        }

        private void OnClickAssoAgricultureButton()
        {
            UIManager.Instance.OpenAssosPopUp(UIManager.Instance.assosPopUp, EAssociationCategory.AGRICULTURE);
        }

        private void OnClickAssoEcologyButton()
        {
            UIManager.Instance.OpenAssosPopUp(UIManager.Instance.assosPopUp, EAssociationCategory.ECOLOGIE);
        }

        private void OnClickAssoIndustryButton()
        {
            UIManager.Instance.OpenAssosPopUp(UIManager.Instance.assosPopUp, EAssociationCategory.INDUSTRY);
        }

        private void OnClickAssoEnergyButton()
        {
            UIManager.Instance.OpenAssosPopUp(UIManager.Instance.assosPopUp, EAssociationCategory.ENERGY);
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
