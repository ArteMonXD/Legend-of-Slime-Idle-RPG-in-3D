using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegendsOfSlime.Units.Enemy
{
    public class EnemyActivity : UnitActivity
    {
        public void InstalEnemyMove(Vector3 position)
        {
            nextPosition = position;
        }
    }
}