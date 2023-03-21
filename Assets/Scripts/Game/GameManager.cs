using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfSlime.Units;
using LegendsOfSlime.Units.Player;
using LegendsOfSlime.Global.Enemy_M;
using LegendsOfSlime.Units.Enemy;
using LegendsOfSlime.Global.Interface;
using System;

namespace LegendsOfSlime.Global.Game_M
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get { return _instance; }
        }
        [Header("Sections Info")]
        [SerializeField] private int lengthSection = 5;
        private int gameStage;
        public int GetGameSection
        {
            get { return (Mathf.FloorToInt(gameStage / lengthSection) + (gameStage % lengthSection != 0 ? 1 : 0));}
        }
        public int GetGameStageInSection
        {
            get { return gameStage - (lengthSection * (GetGameSection - 1)); }
        }
        [Header("Stations Parameters")]
        [SerializeField] private float distanceToNextPosition;
        public float GetDistanceToNextPosition
        {
            get { return distanceToNextPosition; }
        }
        [Header("Participants")]
        [SerializeField] private Player player;
        [SerializeField] private EnemyManager enemyManager;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(gameObject);
        }
        void Start()
        {
            player = Player.Instance;
            enemyManager = EnemyManager.Instance;
            CallPlayerMove();
            enemyManager.CreateUnits();
        }
        void Update()
        {

        }
        public void EnemyByAttack()
        {
            enemyManager.StartMoveSquade(GetGameStageInSection);
            Enemy enemy = enemyManager.GetEnemy(GetGameStageInSection);
            if (enemy != null)
                player.StartAttack(enemy);
            else
                CallPlayerMove();
        }

        private void CallPlayerMove()
        {
            player.StopAttack();
            if (gameStage == lengthSection)
            {
                if(!player.isDeath)
                    GameInterface.Instance.EndGamePanel(true);
                return;
            }
            player.Health();
            player.StartMove(distanceToNextPosition);
            gameStage++;
        }

        public void DeathEnemy()
        {
            Economy_M.EconomyManager.Instance.Earned(GetGameStageInSection);
            EnemyByAttack();
        }
    }
}

