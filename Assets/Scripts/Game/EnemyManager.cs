using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfSlime.Units.Enemy;
using LegendsOfSlime.Global.Game_M;

namespace LegendsOfSlime.Global.Enemy_M
{
    public class EnemyManager : MonoBehaviour
    {
        private static EnemyManager _instance;
        public static EnemyManager Instance
        {
            get { return _instance; }
        }
        [SerializeField] private GameObject[] prefabs;
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private float offsetPosition;
        [SerializeField] private float delayMoveEnemy;
        [SerializeField] private float toPlayerDistance;
        [SerializeField] private int enemySquadeCountPull;
        [SerializeField] private List<EnemysSquade> enemysSquades = new List<EnemysSquade>();
        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(gameObject);
        }
        public void CreateUnits()
        {
            for(int i = 0; i < enemySquadeCountPull; i++)
            {
                Vector3 pos = startPosition;
                pos.x += offsetPosition * i;
                GameObject gameObject = new GameObject();
                gameObject.name = "Enemy Squade " + i;
                gameObject.transform.position = pos;
                gameObject.transform.parent = transform;
                EnemysSquade enemys = gameObject.AddComponent<EnemysSquade>();
                enemys.Init(GameManager.Instance.GetGameSection, GameManager.Instance.GetGameStageInSection + i, prefabs[i != (enemySquadeCountPull -1)?0:1], pos, (i != (enemySquadeCountPull - 1) ? false : true), delayMoveEnemy, toPlayerDistance);
                enemysSquades.Add(enemys);
            }
        }
        public void StartMoveSquade(int index)
        {
            index -= 1;
            enemysSquades[index].EnemysMove();
        }
        public Enemy GetEnemy(int index)
        {
            if (index > enemysSquades.Count)
                return null;
            index -= 1;
            return enemysSquades[index].GetEnemy();
        }
    }
}

