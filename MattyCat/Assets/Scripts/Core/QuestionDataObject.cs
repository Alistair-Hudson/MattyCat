using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MattyMacCat.Core
{
    [CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question", order = 0)]
    public class QuestionDataObject : ScriptableObject
    {
        [SerializeField]
        [TextArea]
        private string question = "";
        public string Question { get => question; }

        [SerializeField]
        private float answer = 0f;
        public float Answer { get => answer; }

        [SerializeField]
        private int grade = 1;
        public int Grade { get => grade; }

        [SerializeField]
        private int level = 0;
        public int Level { get => level; }
    }
}