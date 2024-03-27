using System.Collections.Generic;
using UnityEngine;


namespace AFSInterview.Combat
{
    public class DamageProcessor
    {
        public DamageProcessor(Health health, List<DamageOverrides> damageOverrides, int armourPoints, int damage,
            string tag)
        {
            _health = health;
            _armourPoints = armourPoints;
            _damage = damage;
            _tag = tag;
            _damageOverrides = damageOverrides;
        }

        #region Public Methods

        public void ProcessDamage(DamageData damageData)
        {
            int damage = Mathf.Max(1, damageData.DamageValue - _armourPoints);

            Debug.Log($"{_tag} Got {damage.ToString()} points of damage");

            _health.GetDamage(damage);
        }

        public DamageData CreateDamageData(Unit target)
        {
            return new DamageDataBuilder(_damage).AddOverride(target, _damageOverrides).ToDamageData();
        }

        #endregion Public Methods

        #region Private Variables

        private readonly Health _health;
        private readonly string _tag;

        private readonly int _armourPoints;
        private readonly List<DamageOverrides> _damageOverrides;

        private readonly int _damage;

        #endregion Private Variables
    }
}