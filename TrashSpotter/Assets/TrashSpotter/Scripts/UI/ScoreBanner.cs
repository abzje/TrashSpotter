using UnityEngine;
using UnityEngine.UI;

public class ScoreBanner : MonoBehaviour
{
    [SerializeField] private Image seedFiller = null;
    [SerializeField] private Image levelFiller = null;
    [SerializeField] private Text seedText = null;
    [SerializeField] private Text levelText = null;
    [SerializeField] private Text moneyText = null;
    [SerializeField] private GameObject seedContainer = null;
    
    //Seed
    private int scoreToGetSeed = 100;
    private int _currentSeedScore = 0;

    //Level
    private float scoreToPassLevel = 100;
    private float _currentLevelScore = 0;
    private int currentLevel = 0;

    //Money
    private int _currentMoney = 0;

    /// <summary>
    /// Get or set the seed score and update score banner graphics
    /// </summary>
    public int seedScore
    {
        get => _currentSeedScore;
        set
        {
            float lDivideRest = ((float)value / scoreToGetSeed) % 1;

            //Image fill amount
            if (value >= scoreToGetSeed * seedContainer.transform.childCount) seedFiller.fillAmount = 1;
            else seedFiller.fillAmount = lDivideRest * scoreToGetSeed / scoreToGetSeed;

            seedText.text = value+"";

            //Seed images
            for (int i = 1; i < seedContainer.transform.childCount+1; i++)
            {
                if (value >= scoreToGetSeed * i)
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

            if (value > scoreToPassLevel)
            {
                currentLevel++;
                levelText.text = currentLevel+"";
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
            moneyText.text = value+"";
        }
    }
}
