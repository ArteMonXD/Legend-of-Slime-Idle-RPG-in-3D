using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LegendsOfSlime.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        [SerializeField] private DamageIndicator damageValue;
        protected UnitState status;
        protected UnitActivity activity;
        protected UnitCharacteristics characteristics;

        protected Unit currentUnitAttack;
        public bool isDeath;

        void Update()
        {
            Move();
            Attack();
        }

        #region MovePlayer
        [ContextMenu("StartMove")]
        public virtual void StartMove(float nextPoaitionDistance)
        {
            status.SwitchWalkStatus();
        }
        private void Move()
        {
            if (isDeath)
                return;
            if (status.GetWalkStatus)
                activity.Move();
        }
        public virtual void StopMove()
        {
            status.SwitchWalkStatus();
        }
        #endregion

        #region Attack
        public void StartAttack(Unit unitAttack)
        {
            if (isDeath)
                return;
            if(!status.GetAttackStatus)
                status.SwitchAttackStatus();
            currentUnitAttack = unitAttack;
        }
        public void Attack()
        {
            if (isDeath)
                return;

            if (status.GetAttackStatus && currentUnitAttack != null)
                activity.AttackLaunch(characteristics.GetCurrentAttackSpeed, currentUnitAttack, characteristics.CurrentAttack);
        }
        public void StopAttack()
        {
            if (isDeath)
                return;
            if(status.GetAttackStatus)
                status.SwitchAttackStatus();
            currentUnitAttack = null;
        }
        #endregion
        #region Damage
        public void GetDamage(float damageValue)
        {
            if (isDeath)
                return;


            if (characteristics.Damage(damageValue))
            {
                isDeath = true;
                status.StateDeath();
                Death();
            }
            else
                status.StateDamage();
            DamageIndicatorUpdate(Mathf.RoundToInt(damageValue));
        }
        protected virtual void Death()
        {
            StopMove();
            Destroy(gameObject, 1.5f);
        }
        #endregion

        protected void AttackAnimation()
        {
            status.StateAttack();
        }
        private void DamageIndicatorUpdate(int damage)
        {
            UpdateHealthBar();
            damageValue.Active(damage);
        }
        protected void UpdateHealthBar()
        {
            healthBar.value = characteristics.GetHealth / characteristics.HealthMax;
        }
    }
}

