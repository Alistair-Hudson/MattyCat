using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MattyMacCat.Core
{
    public class ProblemController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text questionTextField = null;
        [SerializeField]
        private TMP_InputField answerInputField = null;
        [SerializeField]
        private Button submitButton = null;
        [SerializeField]
        private EnemyController enemy = null;

        private QuestionDataBase.QuestionData questionData;

        private string userAnswer = "";

        private void Start()
        {
            SetQuestion();

            answerInputField.onValueChanged.AddListener(SetAnswer);
            submitButton.onClick.AddListener(CheckAnswer);
        }

        private void SetQuestion()
        {
            questionData = QuestionDataBase.GetQuestion(GameController.Grade, GameController.Level);
            questionTextField.text = questionData.Question;
        }

        private void CheckAnswer()
        {
            float answer = float.Parse(userAnswer);
            Debug.Log($"Correct: {answer == questionData.Answer}");
            bool reset = false;
            if (answer == questionData.Answer)
            {
                reset = GameController.HitEnemy();
                if (!reset)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            else
            {
                reset = GameController.HitPlayer();
                SetQuestion();
                answerInputField.text = "";
            }

            if (reset)
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