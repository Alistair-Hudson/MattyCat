using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MattyMacCat.Core
{
    public class SystemController : MonoBehaviour
    {
        [SerializeField]
        private static int maxHits = 10;

        public static int Grade = 0;
        public static int Level = -1;

        private static int playerHitPoints = 10;
        public static int PlayerHitPoints { get => playerHitPoints; }

        private static int enemyHitPoints = 10;
        public static int EnemyHitPoints { get => enemyHitPoints; }

        private static EnemySpawnDatabase spawnDatabase = null;
        private static EnemySpawnDatabase SpawnDatabase { get => spawnDatabase; }

        private void Awake()
        {
            spawnDatabase = (EnemySpawnDatabase)Resources.Load("EnemySpawnDatabase");
        }

        public static bool HitPlayer()
        {
            playerHitPoints--;
            if (playerHitPoints <= 0)
            {
                ResetGame();
                return true;
            }
            return false;
        }

        public static bool HitEnemy()
        {
            enemyHitPoints--;
            if (enemyHitPoints <= 0)
            {
                ResetGame();
                return true;
            }
            return false;
        }

        private static void ResetGame()
        {
            playerHitPoints = maxHits;
            enemyHitPoints = maxHits;
        }
    }
}