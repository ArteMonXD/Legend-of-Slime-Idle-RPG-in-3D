using UnityEngine;
using LegendsOfSlime.Global.Game_M;

namespace LegendsOfSlime.Units.Enemy
{
    [RequireComponent(typeof(EnemyStatus), typeof(EnemyActivity), typeof(EnemyCharacteristics))]
    public class Enemy : Unit
    {
        private Vector3 nextPosition;
        public Vector3 SetNextPosition
        {
            set { nextPosition = value; }
        }
        private bool isBoss;
        public bool SetBoss
        {
            set { isBoss = value; }
        }
        private void Awake()
        {
            status = GetComponent<EnemyStatus>();
            activity = GetComponent<EnemyActivity>();
            characteristics = GetComponent<EnemyCharacteristics>();
            activity.ReachedSignalEvent += StopMove;
            activity.AttackedSignalEvent += AttackAnimation;
        }

        public override void StartMove(float nextPoaitionDistance)
        {
            base.StartMove(nextPoaitionDistance);
            (activity as EnemyActivity).InstalEnemyMove(nextPosition);
        }
        public override void StopMove()
        {
            base.StopMove();
            StartAttack(Player.Player.Instance);
        }
        protected override void Death()
        {
            base.Death();
            GameManager.Instance.DeathEnemy();
        }

        public void SetLevel(int levelParameters)
        {
            (characteristics as EnemyCharacteristics).SetBossParameter(isBoss);
            (characteristics as EnemyCharacteristics).SetLevelEnemy(levelParameters);
        }
    }
}
