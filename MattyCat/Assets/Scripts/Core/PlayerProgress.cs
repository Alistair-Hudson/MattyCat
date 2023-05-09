using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MattyMacCat.Core
{
    public class PlayerProgress : MonoBehaviour
    {
        private int _playerLevel = 0;
        public int PlayerLevel { get => _playerLevel; }
        private float _experienceNeeded = 0;
        public float ExperiencedNeeded { get => _experienceNeeded; }
        private float _currentExperience = 0;
        public float CurrentExperience { get => _currentExperience; }

        public UnityEvent OnExperienceGained = new UnityEvent();
        public UnityEvent OnLevelUp = new UnityEvent();

        private void Awake()
        {
            GameController.OnEnemyHit.AddListener(AddExperience);
            UpdateExperienceNeeded();
        }

        private void UpdateExperienceNeeded()
        {
            _experienceNeeded = 100 * _playerLevel + 100;
            OnLevelUp.Invoke();
        }

        public void AddExperience(float exp)
        {
            _currentExperience += exp;
            OnExperienceGained.Invoke();
            if (_currentExperience > _experienceNeeded)
            {
                _currentExperience = _currentExperience - _experienceNeeded;
                _playerLevel++;
                UpdateExperienceNeeded();
            }
        }
    }
}