using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MattyCat.Core
{
    public class ProblemController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text questionTextField = null;
        [SerializeField]
        private TMP_InputField answerInputField = null;
        [SerializeField]
        private Button submitButton = null;

        private QuestionDataBase.QuestionData questionData;

        private string userAnswer = "";

        private void Start()
        {
            questionData = QuestionDataBase.GetQuestion(1);
            questionTextField.text = questionData.Question;

            answerInputField.onValueChanged.AddListener(SetAnswer);
            submitButton.onClick.AddListener(CheckAnswer);
        }

        private void CheckAnswer()
        {
            float answer = float.Parse(userAnswer);
            Debug.Log($"Correct: {answer == questionData.Answer}");
            bool reset = false;
            if (answer == questionData.Answer)
            {
                reset = SystemInformation.HitEnemy();
            }
            else
            {
                reset = SystemInformation.HitPlayer();
            }

            if (!reset)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }

        private void SetAnswer(string arg0)
        {
            if (string.IsNullOrEmpty(arg0))
            {
                submitButton.interactable = false;
                userAnswer = "";
            }
            else
            {
                submitButton.interactable = true;
                userAnswer = arg0;
            }
        }
    }
}