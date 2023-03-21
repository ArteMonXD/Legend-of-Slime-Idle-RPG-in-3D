using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LegendsOfSlime.Units
{
    public abstract class UnitActivity : MonoBehaviour
    {
        [Header("Move")]
        [SerializeField] private Transform currentTrans;
        [SerializeField] private float speedMove;
        protected private Vector3 nextPosition;
        public delegate void ReachedSignalHandle();
        public event ReachedSignalHandle ReachedSignalEvent;
        [Header("Attack")]
        protected float currentTimeAttack;
        public delegate void AttackedSignalHandle();
        public virtual event AttackedSignalHandle AttackedSignalEvent;
        // Start is called before the first frame update
        void Start()
        {
            currentTrans = transform;
        }

        public void Move()
        {
            if (currentTrans.position != nextPosition)
                currentTrans.position = Vector3.MoveTowards(currentTrans.position, nextPosition, speedMove * Time.deltaTime);
            else
                ReachedSignalEvent?.Invoke();
        }
        protected virtual void InstalNextPosition(float distanceToNextPosition)
        {
            nextPosition = currentTrans.position;
            nextPosition.x += distanceToNextPosition;
        }
        public void AttackLaunch(float speedAttack, Unit attacked, float valueAttack)
        {
            if(currentTimeAttack < speedAttack)
            {
                currentTimeAttack += Time.deltaTime;
            }
            else
            {
                Attack(attacked, valueAttack);
            }
        }
        protected virtual void Attack(Unit attacked, float valueAttack)
        {
            attacked.GetDamage(valueAttack);
            AttackedSignalEvent?.Invoke();
            currentTimeAttack = 0;
        }
    }
}

