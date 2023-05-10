using MattyMacCat.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MattyMacCat.UI
{
    public class ExperienceDisplay : MonoBehaviour
    {
        [SerializeField]
        private Image _experienceBar = null;

        private PlayerProgress _playerProgress = null;

        private void Awake()
        {
            _playerProgress = GetComponentInParent<PlayerProgress>();
            _playerProgress.OnExperienceGained.AddListener(UpdateDisplay);
            _playerProgress.OnLevelUp.AddListener(ResetBar);
        }

        private void Start()
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            _experienceBar.fillAmount = _playerProgress.CurrentExperience / _playerProgress.ExperiencedNeeded;
        }

        private void ResetBar()
        {
            _experienceBar.fillAmount = 0;
        }
    }
}