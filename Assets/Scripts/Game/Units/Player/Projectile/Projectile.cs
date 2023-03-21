using UnityEngine;
using LegendsOfSlime.Global;

namespace LegendsOfSlime.Units.Player
{
    public class Projectile : MonoBehaviour
    {
        Player owner;
        private Unit attackedUnit;
        private float valueAttack;
        private float yValueMax = 1f;
        [SerializeField] private float xMin;
        [SerializeField] private float xMax;
        [SerializeField] private float currentX;
        private float speed = 5f;
        private bool start;
        private void OnTriggerEnter(Collider other)
        {
            if (attackedUnit == null)
                return;
            if (other.gameObject == attackedUnit.gameObject)
            {
                start = false;
                gameObject.SetActive(false);
                attackedUnit.GetDamage(valueAttack);
            }
        }
        // Update is called once per frame
        void Update()
        {
            Move();
        }
        public void SetAttackInfo(Unit attacked, float attackValue, Player player)
        {
            attackedUnit = attacked;
            valueAttack = attackValue;
            owner = player;
            xMin = owner.transform.position.x;
            xMax = attackedUnit.transform.position.x;
            transform.position = new Vector3(owner.transform.position.x, yValueMax, owner.transform.position.z);
            currentX = xMin;
            gameObject.SetActive(true);
            start = true;
        }
        private void Move()
        {
            if (!start)
                return;

            currentX += Time.deltaTime * speed;
            transform.position = new Vector3(currentX, yValueMax, 0);
        }
    }
}

