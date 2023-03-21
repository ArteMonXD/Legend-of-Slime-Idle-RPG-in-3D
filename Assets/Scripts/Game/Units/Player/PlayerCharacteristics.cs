using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegendsOfSlime.Units.Player
{
    public class PlayerCharacteristics : UnitCharacteristics
    {
        void Start()
        {
            currentHealth = healthBase;
        }
        public int GetLevelCharacteristic(Global.GlobalConstance.UnitCharacteristics unitCharacteristics)
        {
            switch (unitCharacteristics)
            {
                case Global.GlobalConstance.UnitCharacteristics.ATK:
                    return attackLevel;
                case Global.GlobalConstance.UnitCharacteristics.HP:
                    return healthLevel;
                case Global.GlobalConstance.UnitCharacteristics.S_ATK:
                    return levelAttackSpeed;
                default:
                    return 0;
            }
        } 
        public void Upgrade(Global.GlobalConstance.UnitCharacteristics unitCharacteristics)
        {
            switch (unitCharacteristics)
            {
                case Global.GlobalConstance.UnitCharacteristics.ATK:
                    SetLevelAttack(attackLevel+1);
                    break;
                case Global.GlobalConstance.UnitCharacteristics.HP:
                    SetLevelHealth(healthLevel+1);
                    break;
                case Global.GlobalConstance.UnitCharacteristics.S_ATK:
                    LevelUpSpeedAttack();
                    break;
            }
        }
        protected override void SetLevelHealth(int levelHealth)
        {
            healthLevel  = levelHealth;
            currentHealth += healthBase;
        }
        private void LevelUpSpeedAttack()
        {
            levelAttackSpeed++;
        }
        public void Health()
        {
            currentHealth = HealthMax;
        }
    }
}

