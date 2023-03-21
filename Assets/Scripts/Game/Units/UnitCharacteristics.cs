using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegendsOfSlime.Units
{
    public class UnitCharacteristics : MonoBehaviour
    {
        [Header("AttackSpeed")]
        [SerializeField] protected float attackSpeedBase = 1.8f;
        [SerializeField] protected int levelAttackSpeed = 1;
        [SerializeField] private float multipilierAttackSpeed = 0.1f;
        public float GetCurrentAttackSpeed
        {
            get { return attackSpeedBase - ((levelAttackSpeed - 1) * multipilierAttackSpeed); }
        }
        [Header("Attack")]
        [SerializeField] protected int attackLevel;
        [SerializeField] protected float attackBase = 20;
        public float CurrentAttack
        {
            get { return (attackLevel * attackBase); }
        }
        [Header("Health")]
        [SerializeField] protected float healthBase = 100;
        [SerializeField] protected int healthLevel;
        public float HealthMax
        {
            get { return healthBase * healthLevel; }
        }
        [SerializeField] protected float currentHealth;
        public float GetHealth
        {
            get { return currentHealth; }
        }
        
        public bool Damage(float damageValue)
        {
            currentHealth -= damageValue;
            if (currentHealth <= 0)
                return true;
            else
                return false;
        }

        protected void SetLevelAttack(int levelAttack)
        {
            attackLevel = levelAttack;
        }

        protected virtual void SetLevelHealth(int levelHealth)
        {
            healthLevel = levelHealth;
            currentHealth = healthBase*healthLevel;
        }
    }
}

