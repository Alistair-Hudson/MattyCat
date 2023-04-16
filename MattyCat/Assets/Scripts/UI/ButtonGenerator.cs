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

        void OnEnable()
        {
            foreach (var key in QuestionDataBase.DataBase.Keys)
            {
                Button newButton = Instantiate(buttonPrefab, transform);
                newButton.GetComponentInChildren<TMP_Text>().text = key.ToString();
                newButton.onClick.AddListener(delegate { 
                    SystemInformation.Grade = key;
                    SystemInformation.Level = 1;
                    Debug.Log($"Grade selected: {key}");
                    SceneManager.LoadScene("MainGamePlayScene");
                });
            }
        }

        private void OnDisable()
        {
            var buttons = GetComponentsInChildren<Button>();
            foreach(var button in buttons)
            {
                Destroy(button.gameObject);
            }
        }
    }
}