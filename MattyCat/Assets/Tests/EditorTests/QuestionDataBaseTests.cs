using System.Collections;
using System.Collections.Generic;
using MattyCat.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MattyCat.Test.Editor
{
    public class QuestionDataBaseTests
    {
        [SetUp]
        public void SetUp()
        {
            var obj = new GameObject();
            var dataBase = obj.AddComponent<QuestionDataBase>();
            dataBase.Awake();
        }

        [Test]
        public void QuestionDataBase_PopulateDataBase_Correct()
        {
            //Arrange

            //Act

            //Assert
            Assert.Greater(QuestionDataBase.DataBase.Count, 0, "Database has failed to populate");
        }

        [Test]
        public void QuestionDataBase_GetQuestionFromAExistingGrade_Correct()
        {
            //Arrange

            //Act

            //Assert
            Assert.NotNull(QuestionDataBase.GetQuestion(1), "Failed to get a question");
        }

        [Test]
        public void QuestionDataBase_GetQuestionFromANonExistingGrade_Incorrect()
        {
            //Arrange

            //Act
            var qd = QuestionDataBase.GetQuestion(-1);
            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(qd.Question), "Got a question");
        }
    }
}