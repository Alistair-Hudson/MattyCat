using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MattyMacCat.Core
{
    public class EnemyController : MonoBehaviour
    {
        private GameObject enemy = null;
        private Animator enemyAnimation = null;

        private void Start()
        {
            var prefab = GameController.SpawnDatabase.GetEnemey(GameController.Grade, GameController.Level);
            enemy = Instantiate(prefab, transform);
            enemyAnimation = enemy.GetComponentInChildren<Animator>();
        }

        public void CallAttack()
        {
            enemyAnimation.SetTrigger("Atack");
        }

        public void CallHit()
        {
            enemyAnimation.SetTrigger("Hit");
        }
    }
}