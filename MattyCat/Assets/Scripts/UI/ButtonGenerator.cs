using MattyMacCat.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MattyMacCat.UI
{
    public class ButtonGenerator : MonoBehaviour
    {
        [SerializeField]
        private Button buttonPrefab = null;

        private void OnEnable()
        {
            GenerateGradeButtons();
        }

        private void OnDisable()
        {
            DestroyAllButtons();
        }

        private void DestroyAllButtons()
        {
            var buttons = GetComponentsInChildren<Button>();
            foreach (var button in buttons)
            {
                Destroy(button.gameObject);
            }
        }

        private void GenerateGradeButtons()
        {
            foreach (var grade in QuestionDataBase.DataBase.Keys)
            {
                Button newButton = Instantiate(buttonPrefab, transform);
                newButton.GetComponentInChildren<TMP_Text>().text = $"{grade}";
                newButton.onClick.AddListener(delegate {
                    DestroyAllButtons();
                    foreach (var level in QuestionDataBase.DataBase[grade].Keys)
                    {
                        GenrateLevelButtons(grade, level);
                    }
                    Button backButton = Instantiate(buttonPrefab, transform);
                    backButton.GetComponentInChildren<TMP_Text>().text = "Back";
                    backButton.onClick.AddListener(delegate {
                        DestroyAllButtons();
                        GenerateGradeButtons();
                    });
                });
            }
        }

        private void GenrateLevelButtons(int grade, int level)
        {
            Button newButton = Instantiate(buttonPrefab, transform);
            newButton.GetComponentInChildren<TMP_Text>().text = $"{grade}.{level}";
            newButton.onClick.AddListener(delegate {
                GameController.Grade = grade;
                GameController.Level = level;
                Debug.Log($"Grade selected: {grade}.{level}");
                SceneManager.LoadScene("MainGamePlayScene");
            });
        }
    }
}