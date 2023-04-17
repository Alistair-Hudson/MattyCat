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