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
        public List<EnemyData> EnemyDatas { get => enemyDatas; }
    }
}