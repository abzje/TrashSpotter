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
        [SerializeField] private Image treeTopImage = null;

        [Header ("Money")]
        [SerializeField] private Text moneyValueText = null;

        private void Start()
        {
            assoHumanButton.onClick.AddListener(OnClickAssoHumanButton);
            assoAgricultureButton.onClick.AddListener(OnClickAssoAgricultureButton);
            assoEcologyButton.onClick.AddListener(OnClickAssoEcologyButton);
            assoIndustryButton.onClick.AddListener(OnClickAssoIndustryButton);
            assoEnergyButton.onClick.AddListener(OnClickAssoEnergyButton);
        }

        private void OnClickAssoHumanButton()
        {
            UIManager.Instance.OpenPopUpAndFillIt(UIManager.Instance.assosPopUp, PopUpFillableDynamicaly.enAssoCategory.Human);
        }

        private void OnClickAssoAgricultureButton()
        {
            UIManager.Instance.OpenPopUpAndFillIt(UIManager.Instance.assosPopUp, PopUpFillableDynamicaly.enAssoCategory.Agriculture);
        }

        private void OnClickAssoEcologyButton()
        {
            UIManager.Instance.OpenPopUpAndFillIt(UIManager.Instance.assosPopUp, PopUpFillableDynamicaly.enAssoCategory.Ecology);
        }

        private void OnClickAssoIndustryButton()
        {
            UIManager.Instance.OpenPopUpAndFillIt(UIManager.Instance.assosPopUp, PopUpFillableDynamicaly.enAssoCategory.Industry);
        }

        private void OnClickAssoEnergyButton()
        {
            UIManager.Instance.OpenPopUpAndFillIt(UIManager.Instance.assosPopUp, PopUpFillableDynamicaly.enAssoCategory.Energy);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            assoHumanButton.onClick.RemoveListener(OnClickAssoHumanButton);
            assoAgricultureButton.onClick.RemoveListener(OnClickAssoAgricultureButton);
            assoEcologyButton.onClick.RemoveListener(OnClickAssoEcologyButton);
            assoIndustryButton.onClick.RemoveListener(OnClickAssoIndustryButton);
            assoEnergyButton.onClick.RemoveListener(OnClickAssoEnergyButton);

        }
    }
}
