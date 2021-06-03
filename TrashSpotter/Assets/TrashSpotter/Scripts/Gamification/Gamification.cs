using System;
using UnityEngine;

namespace Com.TrashSpotter
{
    public class Gamification : MonoBehaviour
    {
        [Header("Scores Settings")]
        [SerializeField] private int _scoreToGetSeed = 100;
        [SerializeField] private float _scoreToPassLevel = 100;

        [Header("Samsh Seed Settings")]
        [SerializeField] private int _smashCountToLevelUp = 10;

        public Action OnSmashSeedComplete;

        public int ScoreToGetSeed => _scoreToGetSeed;
        public float ScoreToPassLevel => _scoreToPassLevel;
        public int SmashCountToLevelUp => _smashCountToLevelUp;

        private static Gamification instance;
        public static Gamification Instance => instance;

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
