using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace MattyMacCat.Core
{
    public class GameController : MonoBehaviour
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
        public static EnemySpawnDatabase SpawnDatabase { get => spawnDatabase; }

        public static UnityEvent OnPlayerHit = new UnityEvent();
        public static UnityEvent<float> OnEnemyHit = new UnityEvent<float>();

        private void Awake()
        {
            if (spawnDatabase == null)
            {
                spawnDatabase = (EnemySpawnDatabase)Resources.Load("EnemySpawnDatabase");
            }
        }

        public static bool HitPlayer()
        {
            playerHitPoints--;
            OnPlayerHit.Invoke();
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
            OnEnemyHit.Invoke(Grade);
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