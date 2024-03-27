using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    public class Unit : MonoBehaviour
    {
        public string name;
        public Army army;

        public virtual void Tick()
        {
            if (_health > 0)
            {
                Debug.Log($"Tick from {name}");
                Attack();
            }
            else
            {
                Debug.Log($"QUIT TICKING A DEAD BODY");
            }
        }

        public void Attack()
        {
            Unit target = GetTarget();
            Debug.Log($"Attacking {target.name}");

            target.ApplyDamage(4);
        }

        //TODO: TO AN SEPARATE CLASS
        private Unit GetTarget()
        {
            List<Unit> opponents = army.Opponent.Units;

            return opponents[Random.Range(0, opponents.Count)];
        }

        public void ApplyDamage(int value)
        {
            int damage = Mathf.Max(1, value - armourPoints);

            Debug.Log($"{name} Got {damage} points of damage");
            _health -= damage;

            if (IsDead())
                Die();
        }

        private void Die()
        {
            Debug.Log($"{name} is dying");

            army.NoteDeath(this);

            gameObject.SetActive(false);
        }

        private int _health = 6;
        private int armourPoints = 2;

        public bool IsDead()
        {
            return _health <= 0;
        }
    }
}