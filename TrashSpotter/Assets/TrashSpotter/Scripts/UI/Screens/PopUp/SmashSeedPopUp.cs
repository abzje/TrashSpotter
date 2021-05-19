using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Com.TrashSpotter
{
    public class SmashSeedPopUp : PopUp
    {
        [SerializeField] private Button cancelButton = null;
        [SerializeField] private Button smashSeedButton = null;
        [SerializeField] private Image seed = null;
        [SerializeField] private Image seedFiller = null;
        [SerializeField] private Image flashImage = null;

        [Header("Settings")]
        [SerializeField] private int smashCountToLevelUp = 0;

        private int smashCount = 0;
        private Tween fadeTween;

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
            seedFiller.fillAmount = 0;
            flashImage.transform.localScale = Vector3.one / 10;
        }

        private void OnClickCancel()
        {
            UIManager.Instance.ClosePopUp(this);
        }

        private void OnClickSmashSeed()
        {
            smashCount++;

            float ratio = (float)smashCount / smashCountToLevelUp;

            flashImage.transform.localScale = Vector3.one / 10;

            var lColor = flashImage.color;
            lColor.a = 1f;
            flashImage.color = lColor;

            //Shake seed
            seed.transform.DOShakePosition(1.5f, 10, 10, 90);

            //scale effect
            flashImage.transform.DOScale(1, 0.15f);

            //fade effect
            if (fadeTween != null) fadeTween.Kill();
            fadeTween = flashImage.DOFade(0, 0.7f);

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
