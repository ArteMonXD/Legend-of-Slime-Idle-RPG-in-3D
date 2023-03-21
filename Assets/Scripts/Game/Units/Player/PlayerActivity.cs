using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegendsOfSlime.Units.Player
{
    public class PlayerActivity : UnitActivity
    {
        [SerializeField] private Projectile[] projectile;
        [SerializeField] private int currentProjectile = 0;
        public event AttackedSignalHandle PlayerAttackedSignalEvent;
        public void InstalPosition(float distance)
        {
            base.InstalNextPosition(distance);
        }

        protected override void Attack(Unit attacked, float valueAttack)
        {
            projectile[currentProjectile].SetAttackInfo(attacked, valueAttack, GetComponent<Player>());
            currentProjectile++;
            if (currentProjectile == projectile.Length)
                currentProjectile = 0;
            currentTimeAttack = 0;
            PlayerAttackedSignalEvent?.Invoke();
        }
    }
}

