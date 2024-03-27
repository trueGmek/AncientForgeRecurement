using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    public class Unit : MonoBehaviour
    {
        #region Public Methods

        public void Initialize(UnitBlueprint blueprint, Army army)
        {
            Attributes = blueprint.attributes;
            Health = new Health(blueprint.initialHealth);
            DamageProcessor = new DamageProcessor(Health, blueprint.damageOverrides, blueprint.armour,
                blueprint.damage, tag: Name);

            Health.OnDeath += NoteDeath;

            _action = new AttackAction(this, army, blueprint.attackInterval);
            _army = army;
        }

        public virtual void Tick()
        {
            _action.Perform();
        }

        #endregion Public Methods

        #region Private Methods

        private void NoteDeath()
        {
            Debug.Log($"{Name} is dying");

            _army.NoteDeath(this);

            gameObject.SetActive(false);
        }

        #endregion Private Methods

        #region Public Variables

        public DamageProcessor DamageProcessor { get; private set; }
        public Health Health { get; private set; }
        public List<UnitAttribute> Attributes { get; private set; }
        public string Name => gameObject.name;

        #endregion Public Variables

        #region Private Variables

        private Army _army;
        private IAction _action;

        #endregion Private Variables
    }
}