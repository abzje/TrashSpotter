using DG.Tweening;
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

        [Header("Miscellaneous")]
        [SerializeField] private Transform UIElementContainer = null;
        [SerializeField] private Button treeButton = null;
        [SerializeField] private Text moneyValueText = null;
        [SerializeField] private Image treeImage = null;

        [Header("Blossom Settings")]
        [SerializeField] private AnimationCurve blossomCurve = null;
        [SerializeField] private float blossomMinDuration = 1;
        [SerializeField] private float blossomMaxDuration = 2;
        [SerializeField] private float blossomMinDelay = 0;
        [SerializeField] private float blossomMaxDelay = 2;

        private void Start()
        {
            treeButton.onClick.AddListener(OnClickTree);

            assoHumanButton.onClick.AddListener(OnClickAssoHumanButton);
            assoAgricultureButton.onClick.AddListener(OnClickAssoAgricultureButton);
            assoEcologyButton.onClick.AddListener(OnClickAssoEcologyButton);
            assoIndustryButton.onClick.AddListener(OnClickAssoIndustryButton);
            assoEnergyButton.onClick.AddListener(OnClickAssoEnergyButton);

            Gamification.Instance.OnSmashSeedComplete += BlossomTree;
        }

        private void BlossomTree()
        {
            for (int i = 0; i < treeImage.transform.childCount; i++)
            {
                treeImage.transform.GetChild(i).transform.DOScale(
                    Vector3.one, 
                    Random.Range(blossomMinDuration, blossomMaxDuration))
                .SetEase(blossomCurve)
                .SetDelay(Random.Range(blossomMinDelay, blossomMaxDelay));
            }
            Gamification.Instance.Level++;
        }

        public override void Open()
        {
            Gamification.Instance.ScoreBanner.transform.SetParent(UIElementContainer);
            Gamification.Instance.ScoreBanner.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            animator.SetTrigger("OpenGiveForest");
        }

        public override void Close()
        {
            animator.SetTrigger("OpenGreenoLandFromGiveForest");
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
