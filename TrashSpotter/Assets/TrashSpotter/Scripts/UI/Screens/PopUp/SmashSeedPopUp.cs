using UnityEngine;
using UnityEngine.UI;

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
            seedFiller.fillAmount = ratio;

            Debug.Log(ratio);

            if (ratio == 1)
            {
                UpdateLevel();
                smashCount = 0;
            }
        }

        private void UpdateLevel()
        {

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            cancelButton.onClick.RemoveListener(OnClickCancel);
            smashSeedButton.onClick.RemoveListener(OnClickSmashSeed);
        }
    }
}
