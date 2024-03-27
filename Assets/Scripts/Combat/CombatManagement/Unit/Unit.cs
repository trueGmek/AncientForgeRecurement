using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    public class Unit : MonoBehaviour
    {
        #region Public Methods

        public void Initialize(UnitParameters parameters)
        {
            Health = new Health(parameters.initialHealth);
            DamageProcessor = new DamageProcessor(Health, parameters.armour, parameters.damage, Name);

            Health.OnDeath += NoteDeath;
        }

        public virtual void Tick()
        {
            Attack();
        }

        public void AssignArmy(Army army)
        {
            _army = army;
        }

        #endregion Public Methods

        #region Private Methods

        private void Attack()
        {
            Unit target = GetTarget();
            Debug.Log($"{Name} is attacking {target.Name}");

            target.DamageProcessor.ProcessDamage(DamageProcessor.CreateDamageData());
        }

        private Unit GetTarget()
        {
            List<Unit> opponents = _army.Opponent.Units;

            return opponents[Random.Range(0, opponents.Count)];
        }

        private void NoteDeath()
        {
            Debug.Log($"{Name} is dying");

            _army.NoteDeath(this);

            gameObject.SetActive(false);
        }

        #endregion Private Methods

        #region Public Variables

        private DamageProcessor DamageProcessor { get; set; }
        public Health Health { get; private set; }
        public string Name => gameObject.name;

        #endregion Public Variables

        #region Private Variables

        private Army _army;

        #endregion Private Variables
    }
}