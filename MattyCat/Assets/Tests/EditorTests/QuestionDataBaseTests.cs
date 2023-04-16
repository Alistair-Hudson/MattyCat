using System.Collections;
using System.Collections.Generic;
using MattyMacCat.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MattyMacCat.Test.Editor
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
        public void QuestionDataBase_GetQuestionFromAExistingGradeAndLevel_Correct()
        {
            //Arrange

            //Act

            //Assert
            Assert.NotNull(QuestionDataBase.GetQuestion(1, 1), "Failed to get a question");
        }

        [Test]
        public void QuestionDataBase_GetQuestionFromANonExistingGrade_Incorrect()
        {
            //Arrange

            //Act
            var qd = QuestionDataBase.GetQuestion(-1, 1);
            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(qd.Question), "Got a question");
        }

        [Test]
        public void QuestionDataBase_GetQuestionFromANonExistingLevel_Incorrect()
        {
            //Arrange

            //Act
            var qd = QuestionDataBase.GetQuestion(1, -1);
            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(qd.Question), "Got a question");
        }
    }
}