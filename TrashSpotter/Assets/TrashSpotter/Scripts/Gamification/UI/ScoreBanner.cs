using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class ScoreBanner : MonoBehaviour
    {
        [SerializeField] private Image seedFiller = null;
        [SerializeField] private Image levelFiller = null;
        [SerializeField] private Text seedText = null;
        [SerializeField] private Text levelText = null;
        [SerializeField] private Text moneyText = null;
        [SerializeField] private GameObject seedContainer = null;

        private static ScoreBanner instance;
        public static ScoreBanner Instance => instance;

        private void Awake()
        {
            if (instance)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        /// <summary>
        /// Set the seed score and update score banner graphics
        /// </summary>
        public int seedScore
        {
            set
            {
                float lDivideRest = ((float)value / Gamification.Instance.ScoreToGetSeed) % 1;

                //Image fill amount
                if (value >= Gamification.Instance.ScoreToGetSeed * seedContainer.transform.childCount) seedFiller.fillAmount = 1;
                else seedFiller.fillAmount = lDivideRest * Gamification.Instance.ScoreToGetSeed / Gamification.Instance.ScoreToGetSeed;

                seedText.text = value + "";

                //Seed images
                for (int i = 1; i < seedContainer.transform.childCount + 1; i++)
                {
                    if (value >= Gamification.Instance.ScoreToGetSeed * i)
                    {
                        seedContainer.transform.GetChild(i - 1).GetChild(0).gameObject.SetActive(true);
                    }
                    else seedContainer.transform.GetChild(i - 1).GetChild(0).gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// Set the level score and update score banner graphics
        /// </summary>
        public float levelScore
        {
            set
            {
                levelFiller.fillAmount = (value % Gamification.Instance.ScoreToPassLevel) / Gamification.Instance.ScoreToPassLevel;
            }
        }

        public int level
        {
            set
            {
                levelText.text = "" + Gamification.Instance.Level;
            }
        }

        /// <summary>
        /// Set the money score and update score banner graphics
        /// </summary>
        public int moneyScore
        {
            set
            {
                moneyText.text = value + "";
            }
        }

        private void OnDestroy()
        {
            if (this == instance) instance = null;
        }
    }
}
