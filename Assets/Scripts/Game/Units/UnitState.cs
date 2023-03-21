using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegendsOfSlime.Global;

namespace LegendsOfSlime.Units
{
    public class UnitState : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private bool walkStatus;
        public bool GetWalkStatus
        {
            get { return walkStatus; }
        }
        [SerializeField] private bool attackStatus;
        public bool GetAttackStatus
        {
            get { return attackStatus; }
        }
        
        protected void SetAnimationByTriggerProtected(string state)
        {
            animator.SetTrigger(state);
        }

        protected void  SetAnimationByBoolProtected(string state, bool status)
        {
            animator.SetBool(state, status);
        }

        public void StateAttack()
        {
            SetAnimationByTriggerProtected(GlobalConstance.ATTACK_ANIMATION);
        }

        public void StateDamage()
        {
            SetAnimationByTriggerProtected(GlobalConstance.DAMAGE_ANIMATION);
        }

        public void StateDeath()
        {
            SetAnimationByTriggerProtected(GlobalConstance.DEATH_ANIMATION);
        }

        public void SwitchWalkStatus()
        {
            SetAnimationByBoolProtected(GlobalConstance.WALK_ANIMATION, !walkStatus);
            walkStatus = !walkStatus;
        }
        public void SwitchAttackStatus()
        {
            attackStatus = !attackStatus;
        }
    }
}

