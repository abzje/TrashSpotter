using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Com.TrashSpotter
{
    public class SmashSeedPopUp : PopUp
    {
        [SerializeField] private Button cancelButton = null;
        [SerializeField] private Button smashSeedButton = null;
        [SerializeField] private Image seedFiller = null;

        [Header("Settings")]
        [SerializeField] private int smashCountToLevelUp = 0;

        private int smashCount = 0;

        private void Start()
        {
            cancelButton.onClick.AddListener(OnClickCancel);
            smashSeedButton.onClick.AddListener(OnClickSmashSeed);

            DOTween.Init(false);
        }

        public override void Open()
        {
            base.Open();

            smashCount = 0;
        }

        private void OnClickCancel()
        {
            UIManager.Instance.ClosePopUp(this);
        }

        private void OnClickSmashSeed()
        {
            smashCount++;

            float ratio = (float)smashCount / smashCountToLevelUp;

            //punch on scale effect
            smashSeedButton.transform.DOPunchScale(Vector2.one * 0.4f, 0.1f, 10, 1f);

            //lerp fill amount
            seedFiller.DOFillAmount(ratio, 0.25f).OnComplete(() => 
            {
                if (ratio == 1)
                {
                    UpdateLevel();
                    smashCount = 0;
                }
            } );
        }

        private void UpdateLevel()
        {
            seedFiller.fillAmount = 0;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            cancelButton.onClick.RemoveListener(OnClickCancel);
            smashSeedButton.onClick.RemoveListener(OnClickSmashSeed);
        }
    }
}
