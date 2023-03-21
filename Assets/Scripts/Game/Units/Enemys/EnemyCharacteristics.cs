using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegendsOfSlime.Units.Enemy
{
    public class EnemyCharacteristics : UnitCharacteristics
    {
        public void SetLevelEnemy(int level)
        {
            SetLevelAttack(level);
            SetLevelHealth(level);
        } 

        public void SetBossParameter(bool isBoss)
        {
            if (!isBoss)
                return;
            healthBase *= 1.5f;
            attackBase *= 1.5f;
        }
    }
}

