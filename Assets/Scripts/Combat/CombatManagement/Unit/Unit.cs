using UnityEngine;

namespace AFSInterview.Combat
{
    public class Unit : MonoBehaviour
    {
        #region Public Methods

        public void Initialize(UnitParameters parameters, Army army)
        {
            Health = new Health(parameters.initialHealth);
            DamageProcessor = new DamageProcessor(Health, parameters.armour, parameters.damage, Name);

            Health.OnDeath += NoteDeath;

            _action = new AttackAction(this, army, parameters.attackInterval);
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
        public string Name => gameObject.name;

        #endregion Public Variables

        #region Private Variables

        private Army _army;
        private IAction _action;

        #endregion Private Variables
    }
}