using UnityEngine;

namespace AFSInterview.Combat
{
    public class UnitFXController
    {
        #region Public Methods

        public UnitFXController(Rigidbody rigidbody, Unit unit)
        {
            unit.DamageProcessor.OnGetDamage += ApplyGetDamageEffect;
            _rigidbody = rigidbody;
        }

        #endregion Public Methods

        #region Private Methods

        private void ApplyGetDamageEffect(DamageData damageData)
        {
            float scale = Mathf.Min(10, 3 * damageData.DamageValue);
            _rigidbody.AddForce(scale * Vector3.up, ForceMode.VelocityChange);
        }

        public void ApplyAttackDamageEffect(DamageData damageData, Unit target)
        {
            float scale = Mathf.Min(6, 3 * damageData.DamageValue);

            Vector3 direction = (_rigidbody.transform.position - target.transform.position).normalized;


            _rigidbody.AddForce(scale * direction, ForceMode.VelocityChange);
        }

        #endregion Private Methods


        #region Private Variables

        private readonly Rigidbody _rigidbody;
        private readonly Unit _unit;

        #endregion Private Variables
    }
}