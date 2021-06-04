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

        //Seed
        private int _currentSeedScore = 0;

        //Level
        private float _currentLevelScore = 0;
        private int currentLevel = 0;

        //Money
        private int _currentMoney = 0;

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
            //Update Graphics temporarly
            seedScore = 101;
            levelScore = 101;
            moneyScore = 1000;
        }

        /// <summary>
        /// Get or set the seed score and update score banner graphics
        /// </summary>
        public int seedScore
        {
            get => _currentSeedScore;
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

                _currentSeedScore = value;
            }
        }

        /// <summary>
        /// Get or set the level score and update score banner graphics
        /// </summary>
        public float levelScore
        {
            get => _currentLevelScore;
            set
            {
                _currentLevelScore = value;

                if (value > Gamification.Instance.ScoreToPassLevel)
                {
                    currentLevel++;
                    levelText.text = currentLevel + "";
                }

            }
        }

        /// <summary>
        /// Get or set the money score and update score banner graphics
        /// </summary>
        public int moneyScore
        {
            get => _currentMoney;
            set
            {
                _currentMoney = value;
                moneyText.text = value + "";
            }
        }

        private void OnDestroy()
        {
            if (this == instance) instance = null;
        }
    }
}
