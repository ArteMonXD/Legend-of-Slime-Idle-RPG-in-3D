using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegendsOfSlime.Units.Enemy
{
    public class EnemysSquade : MonoBehaviour
    {
        [SerializeField] private Enemy[] enemys;
        [SerializeField] private float offsetPositon = 8.5f;
        [SerializeField] private float delayMove;
        private int countEnemy = 0;
        private bool boss;
        public bool IsBoss
        {
            get { return boss; }
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        
        public void Init(int countEnemy, int enemyLevel, GameObject prefab, Vector3 position, bool bossStatus, float delay, float distance)
        {
            boss = bossStatus;
            delayMove = delay;
            offsetPositon = distance;
            enemys = new Enemy[countEnemy];
            for (int i = 0; i < (bossStatus ? 1 : countEnemy); i++)
            {
                Enemy enemy = Instantiate(prefab, position, prefab.transform.rotation, transform).GetComponent<Enemy>();
                enemy.SetBoss = bossStatus;
                enemy.SetLevel(enemyLevel);
                if (i != 0)
                {
                    Transform pastEnemy_T = enemys[i - 1].transform;
                    Vector3 pastEnemyPos = pastEnemy_T.position;
                    enemy.transform.position = new Vector3(pastEnemyPos.x + Random.Range(-2, 3), pastEnemyPos.y, pastEnemyPos.z + Random.Range(-2, 3));
                }
                enemys[i] = enemy;
            }
        }
        public void EnemysMove()
        {
            StartCoroutine(MoveStart());
        }

        private IEnumerator MoveStart()
        {
            for(int i = 0;i<enemys.Length; i++)
            {
                Vector3 pos = transform.position;
                pos.x += offsetPositon;
                enemys[i].SetNextPosition = pos;
                enemys[i].StartMove(offsetPositon);

                yield return new WaitForSeconds(delayMove);
            }
        }
        public Enemy GetEnemy()
        {
            if (countEnemy == enemys.Length)
                return null;

            Enemy enemy = enemys[countEnemy];
            countEnemy++;
            return enemy;
        }
    }
}

