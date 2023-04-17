using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MattyMacCat.Core
{
    [CreateAssetMenu(fileName = "EnemySpawnDatabase", menuName = "ScriptableObjects/EnemySpawnDatabase", order = 0)]
    public class EnemySpawnDatabase : ScriptableObject
    {
        [System.Serializable]
        public struct EnemyData
        {
            public int Grade;
            public int Level;
            public GameObject EnemyPrefab;
        }

        [SerializeField]
        private List<EnemyData> enemyDatas = new List<EnemyData>();

        private Dictionary<int, Dictionary<int, List<GameObject>>> enemyDatabase = null;

        private void BuildDataBase()
        {
            enemyDatabase = new Dictionary<int, Dictionary<int, List<GameObject>>>();
            foreach (var data in enemyDatas)
            {
                if (!enemyDatabase.ContainsKey(data.Grade))
                {
                    enemyDatabase.Add(data.Grade, new Dictionary<int, List<GameObject>>());
                }
                if (!enemyDatabase[data.Grade].ContainsKey(data.Level))
                {
                    enemyDatabase[data.Grade].Add(data.Level, new List<GameObject>());
                }
                enemyDatabase[data.Grade][data.Level].Add(data.EnemyPrefab);
            }
        }

        public GameObject GetEnemey(int grade, int level)
        {
            if (enemyDatabase == null) BuildDataBase();
            if (!enemyDatabase.ContainsKey(grade)) return null;
            if (!enemyDatabase[grade].ContainsKey(level)) return null;
            return enemyDatabase[grade][level][Random.Range(0, enemyDatabase[grade][level].Count)];
        }
    }
}