using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MattyCat.Core
{
    public class QuestionDataBase : MonoBehaviour
    {
        public struct QuestionData
        {
            public string Question;
            public float Answer;
        }
        private static Dictionary<int, List<QuestionData>> dataBase = new();
        public static Dictionary<int, List<QuestionData>> DataBase { get => dataBase; }

        public void Awake()
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
                    dataBase.Add(q.Grade, new List<QuestionData>());
                }
                dataBase[q.Grade].Add(qd);
            }
        }

        public static QuestionData GetQuestion(int grade)
        {
            if (!dataBase.ContainsKey(grade)) return default;
            return dataBase[grade][Random.Range(0, dataBase[grade].Count)];
        }
    }
}