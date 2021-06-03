using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

namespace Com.TrashSpotter
{
    public class SmashSeedPopUp : PopUp
    {
        [SerializeField] private Button cancelButton = null;
        [SerializeField] private Button backgroundButton = null;
        [SerializeField] private Button smashSeedButton = null;
        [SerializeField] private Image seed = null;
        [SerializeField] private Image seedFiller = null;
        [SerializeField] private Image flashImage = null;
        [SerializeField] private ParticleSystem smashExplosionEffect = null;

        private int smashCount = 0;
        private Tween fadeTween;

        private void Start()
        {
            cancelButton.onClick.AddListener(OnClickCancel);
            backgroundButton.onClick.AddListener(OnClickCancel);
            smashSeedButton.onClick.AddListener(OnClickSmashSeed);
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

            float ratio = (float)smashCount / Gamification.Instance.SmashCountToLevelUp;

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
                    ScoreBanner.Instance.seedScore -= Gamification.Instance.ScoreToGetSeed;

                    UpdateLevel();
                    smashCount = 0;

                    Transform parentParticle = smashExplosionEffect.transform;

                    float particleMaxLifetime = Mathf.Max(parentParticle.GetChild(0).GetComponent<ParticleSystem>().startLifetime, parentParticle.GetChild(1).GetComponent<ParticleSystem>().startLifetime);

                    //Smash complete particle system
                    smashExplosionEffect.Play();
                    StartCoroutine(OnSmashExplosionComplete(particleMaxLifetime - 0.01f));
                }
            } );
        }

        private IEnumerator OnSmashExplosionComplete(float lifetime)
        {
            yield return new WaitForSeconds(lifetime);

            UIManager.Instance.ClosePopUp(this);
            Gamification.Instance.OnSmashSeedComplete?.Invoke();
        }

        private void UpdateLevel()
        {
            seedFiller.fillAmount = 0;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            cancelButton.onClick.RemoveListener(OnClickCancel);
            backgroundButton.onClick.RemoveListener(OnClickCancel);
            smashSeedButton.onClick.RemoveListener(OnClickSmashSeed);
        }
    }
}
