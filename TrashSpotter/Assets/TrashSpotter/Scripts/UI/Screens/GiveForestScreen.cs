using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class GiveForestScreen : Screen
    {
        [Header ("Button")]
        [SerializeField] private Button assoButton = null;
        [SerializeField] private Button assoAgricultureButton = null;
        [SerializeField] private Button assoEcologyButton = null;
        [SerializeField] private Button assoIndustryButton = null;
        [SerializeField] private Button assoEnergyButton = null;

        [Header ("Tree")]
        [SerializeField] private Image treeTopImage = null;

        [Header ("Money")]
        [SerializeField] private Text moneyValueText = null;

        private static GiveForestScreen instance;
        public static GiveForestScreen Instance => instance;

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
            assoButton.onClick.AddListener(OnClickAssoButton);
            assoAgricultureButton.onClick.AddListener(OnClickAssoAgricultureButton);
            assoEcologyButton.onClick.AddListener(OnClickAssoEcologyButton);
            assoIndustryButton.onClick.AddListener(OnClickAssoIndustryButton);
            assoEnergyButton.onClick.AddListener(OnClickAssoEnergyButton);
        }

        private void OnClickAssoButton()
        {

        }

        private void OnClickAssoAgricultureButton()
        {

        }

        private void OnClickAssoEcologyButton()
        {

        }

        private void OnClickAssoIndustryButton()
        {

        }

        private void OnClickAssoEnergyButton()
        {

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            assoButton.onClick.RemoveListener(OnClickAssoButton);
            assoAgricultureButton.onClick.RemoveListener(OnClickAssoAgricultureButton);
            assoEcologyButton.onClick.RemoveListener(OnClickAssoEcologyButton);
            assoIndustryButton.onClick.RemoveListener(OnClickAssoIndustryButton);
            assoEnergyButton.onClick.RemoveListener(OnClickAssoEnergyButton);

            if (this == instance) instance = null;

        }
    }
}
