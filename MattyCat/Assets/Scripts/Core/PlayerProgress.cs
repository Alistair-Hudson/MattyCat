using MattyMacCat.Saving;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MattyMacCat.Core
{
    public class PlayerProgress : MonoBehaviour, ISaveable
    {
        [System.Serializable]
        public struct PlayerProgessSave
        {
            public int PlayerLevel;
            public float CurrentExperience;
        }

        [SerializeField]
        private string _saveFile = "MattyMacCat";

        private int _playerLevel = 0;
        public int PlayerLevel { get => _playerLevel; }
        private float _experienceNeeded = 0;
        public float ExperiencedNeeded { get => _experienceNeeded; }
        private float _currentExperience = 0;
        public float CurrentExperience { get => _currentExperience; }

        private SavingSystem _savingSystem = null;

        public UnityEvent OnExperienceGained = new UnityEvent();
        public UnityEvent OnLevelUp = new UnityEvent();

        private void Start()
        {
            _savingSystem = GetComponent<SavingSystem>();
            _savingSystem.Load(_saveFile);
            GameController.OnEnemyHit.AddListener(AddExperience);
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
            _savingSystem.Save(_saveFile);
        }

        public object CaptureState()
        {
            var playerProgress = new PlayerProgessSave
            {
                PlayerLevel = _playerLevel,
                CurrentExperience = _currentExperience
            };
            return playerProgress;
        }

        public void RestoreState(object state)
        {
            var playerProgress = (PlayerProgessSave)state;
            _playerLevel = playerProgress.PlayerLevel;
            _currentExperience = playerProgress.CurrentExperience;
            Debug.Log($"Level: {_playerLevel}, Exp: {_currentExperience}");
            UpdateExperienceNeeded();
            OnExperienceGained.Invoke();
        }
    }
}