using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MattyMacCat.Core
{
    public class QuestionDataBase : MonoBehaviour
    {
        public struct QuestionData
        {
            public string Question;
            public float Answer;
        }
        private static Dictionary<int, Dictionary<int, List<QuestionData>>> dataBase = new();
        public static Dictionary<int, Dictionary<int, List<QuestionData>>> DataBase { get => dataBase; }

        private static bool isLoaded = false;

        public void Awake()
        {
            if (isLoaded) return;
            LoadAutoGenerateQuestions();
            LoadWrittenQuestions();
            isLoaded = true;
        }

        private void LoadAutoGenerateQuestions()
        {
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        dataBase.Add(i, new Dictionary<int, List<QuestionData>>());
                        for (int j = 0; j <= 10; j++)
                        {
                            dataBase[i].Add(j, new List<QuestionData>());
                            var questionList = dataBase[i][j];
                            CreateAdditionQuestions(j, questionList);
                        }
                        break;
                    case 2:
                        dataBase.Add(i, new Dictionary<int, List<QuestionData>>());
                        for (int j = 0; j <= 10; j++)
                        {
                            dataBase[i].Add(j, new List<QuestionData>());
                            var questionList = dataBase[i][j];
                            CreateSubtractionQuestions(j, questionList);
                        }
                        break;
                    case 3:
                        dataBase.Add(i, new Dictionary<int, List<QuestionData>>());
                        for (int j = 0; j <= 12; j++)
                        {
                            dataBase[i].Add(j, new List<QuestionData>());
                            var questionList = dataBase[i][j];
                            CreateMultiplicationQuestions(j, questionList);
                        }
                        break;
                    case 4:
                        dataBase.Add(i, new Dictionary<int, List<QuestionData>>());
                        for (int j = 0; j <= 12; j++)
                        {
                            dataBase[i].Add(j, new List<QuestionData>());
                            var questionList = dataBase[i][j];
                            CreateDivisionQuestions(j, questionList);
                        }
                        break;
                }
            }
        }

        private void CreateDivisionQuestions(int i, List<QuestionData> questionList)
        {
            for (int j = 0; j <= 10; j++)
            {
                QuestionData newQuestion = new QuestionData
                {
                    Question = $"{i * j} / {i} =",
                    Answer = j
                };
                questionList.Add(newQuestion);
            }
        }

        private void CreateMultiplicationQuestions(int i, List<QuestionData> questionList)
        {
            for (int j = 0; j <= 10; j++)
            {
                QuestionData newQuestion = new QuestionData
                {
                    Question = $"{i} * {j} =",
                    Answer = i * j
                };
                questionList.Add(newQuestion);
            }
        }

        private void CreateSubtractionQuestions(int i, List<QuestionData> questionList)
        {
            for (int j = 0; j <= 10; j++)
            {
                QuestionData newQuestion = new QuestionData
                {
                    Question = $"{i + j} - {i} =",
                    Answer = j
                };
                questionList.Add(newQuestion);
            }
        }

        private void CreateAdditionQuestions(int i, List<QuestionData> questionList)
        {
            for (int j = 0; j <= 10; j++)
            {
                QuestionData newQuestion = new QuestionData
                {
                    Question = $"{i} + {j} =",
                    Answer = i + j
                };
                questionList.Add(newQuestion);
            }
        }

        private static void LoadWrittenQuestions()
        {
            var questions = Resources.LoadAll("Questions");
            foreach (var question in questions)
            {
                var q = (QuestionDataObject)question;
                var qd = new QuestionData
                {
                    Question = q.Question,
                    Answer = q.Answer
                };

                if (!dataBase.ContainsKey(q.Grade))
                {
                    dataBase.Add(q.Grade, new Dictionary<int, List<QuestionData>>());
                }
                if (!dataBase[q.Grade].ContainsKey(q.Level))
                {
                    dataBase[q.Grade].Add(q.Level, new List<QuestionData>());
                }
                dataBase[q.Grade][q.Level].Add(qd);
            }
        }

        public static QuestionData GetQuestion(int grade, int level)
        {
            if (!dataBase.ContainsKey(grade)) return default;
            if (!dataBase[grade].ContainsKey(level)) return default;
            return dataBase[grade][level][Random.Range(0, dataBase[grade][level].Count)];
        }
    }
}