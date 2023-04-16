using MattyCat.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MattyCat.UI
{
    public class ButtonGenerator : MonoBehaviour
    {
        [SerializeField]
        private Button buttonPrefab = null;

        private void OnEnable()
        {
            GenerateGradeButtons();
            //foreach (var grade in QuestionDataBase.DataBase.Keys)
            //{
            //    foreach (var level in QuestionDataBase.DataBase[grade].Keys)
            //    {
            //        Button newButton = Instantiate(buttonPrefab, transform);
            //        newButton.GetComponentInChildren<TMP_Text>().text = $"{grade}.{level}";
            //        newButton.onClick.AddListener(delegate { 
            //            SystemInformation.Grade = grade;
            //            SystemInformation.Level = level;
            //            Debug.Log($"Grade selected: {grade}.{level}");
            //            SceneManager.LoadScene("MainGamePlayScene");
            //        });
            //    }
            //}
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
                SystemInformation.Grade = grade;
                SystemInformation.Level = level;
                Debug.Log($"Grade selected: {grade}.{level}");
                SceneManager.LoadScene("MainGamePlayScene");
            });
        }
    }
}