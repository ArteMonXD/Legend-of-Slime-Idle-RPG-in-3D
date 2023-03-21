using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfSlime.Units.Enemy;
using LegendsOfSlime.Global.Interface;

namespace LegendsOfSlime.Units.Player
{
    [RequireComponent(typeof(PlayerStatus), typeof(PlayerActivity), typeof(PlayerCharacteristics))]
    public class Player : Unit
    {
        public PlayerCharacteristics PlayerCharacteristics
        {
            get { return (characteristics as PlayerCharacteristics); }
        }
        private static Player _instance;
        public static Player Instance
        {
            get { return _instance; }
        }
        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(gameObject);

            status = GetComponent<PlayerStatus>();
            activity = GetComponent<PlayerActivity>();
            characteristics = GetComponent<PlayerCharacteristics>();
            activity.ReachedSignalEvent += StopMove;
            (activity as PlayerActivity).PlayerAttackedSignalEvent += AttackAnimation;
        }

        public override void StartMove(float nextPositionDistance)
        {
            base.StartMove(nextPositionDistance);
            (activity as PlayerActivity).InstalPosition(nextPositionDistance);
        }

        public override void StopMove()
        {
            base.StopMove();
            Global.Game_M.GameManager.Instance.EnemyByAttack();
        }
        protected override void Death()
        {
            base.Death();
            GameInterface.Instance.EndGamePanel(false);
        }
        public void Health()
        {
            (characteristics as PlayerCharacteristics).Health();
            UpdateHealthBar();
        }
        public int GetLevelCharacteristic(Global.GlobalConstance.UnitCharacteristics unitCharacteristics)
        {
            return (characteristics as PlayerCharacteristics).GetLevelCharacteristic(unitCharacteristics); 
        }
        public void PlayerUpgrade(Global.GlobalConstance.UnitCharacteristics unitCharacteristics)
        {
            (characteristics as PlayerCharacteristics).Upgrade(unitCharacteristics);
            if (unitCharacteristics == Global.GlobalConstance.UnitCharacteristics.HP)
                UpdateHealthBar();
            GameInterface.Instance.UpdateLevelsAndCharacteristic(unitCharacteristics);
        }
    }
}

