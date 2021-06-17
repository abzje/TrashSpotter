using System;
using UnityEngine;

namespace Com.TrashSpotter
{
    public class Gamification : MonoBehaviour
    {
        [Header("Scores Settings")]
        [SerializeField] private int _scoreToGetSeed = 100;
        [SerializeField] private float _scoreToPassLevel = 100;
        [SerializeField] private ScoreBanner _scoreBanner = null;

        [Header("Smash Seed Settings")]
        [SerializeField] private int _smashCountToLevelUp = 10;

        private static Gamification instance;
        public static Gamification Instance => instance;

        public Action OnSmashSeedComplete;

        public ScoreBanner ScoreBanner => _scoreBanner;
        public int SmashCountToLevelUp => _smashCountToLevelUp;
        public int ScoreToGetSeed => _scoreToGetSeed;
        public float ScoreToPassLevel => _scoreToPassLevel;

        private int _money;
        private int _seeds;
        private int _levelXP;
        private int _level;

        public int Money
        {
            get => _money;
            set
            {
                _money = value;
                ScoreBanner.moneyScore = value;
            }
        }

        public int Seeds
        {
            get => _seeds;
            set
            {
                _seeds = value;
                ScoreBanner.seedScore = value;
            }
        }

        /// <summary>
        /// The current level experience of the player (used to calculate the level)
        /// </summary>
        public int LevelXP
        {
            get => _levelXP;
            set
            {
                _levelXP = value;
                ScoreBanner.levelScore = value;

                if (value >= _scoreToPassLevel)
                {
                    Level++;
                }
            }
        }

        /// <summary>
        /// The current level of the player
        /// </summary>
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                ScoreBanner.level = value;
            }
        }

        private void Start()
        {
            Debug.LogWarning("[HERE REPLACE VALUES BY 0 LATTER] Those lines are used to set default money, level xp and seeds scores values for testing purpose.");

            Level = 0;
            Money = 1000;
            LevelXP = 100;
            Seeds = 100;
        }

        private void Awake()
        {
            if (instance)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        private void OnDestroy()
        {
            if (this == instance) instance = null;
        }
    }
}
