using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemInformation : MonoBehaviour
{
    [SerializeField]
    private static int maxHits = 10;

    public static int Grade = 0;

    private static int playerHitPoints = 10;
    public static int PlayerHitPoints { get => playerHitPoints; }

    private static int enemyHitPoints = 10;
    public static int EnemyHitPoints { get => enemyHitPoints; }

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
