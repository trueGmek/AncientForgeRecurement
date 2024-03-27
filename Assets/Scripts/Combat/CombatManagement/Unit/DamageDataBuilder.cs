using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace AFSInterview.Combat
{
    public struct DamageDataBuilder
    {
        #region Public Methods

        public DamageDataBuilder(int damageValue)
        {
            DamageValue = damageValue;
            DamageDealer = null;
        }

        public DamageData ToDamageData()
        {
            return new DamageData(DamageValue, DamageDealer);
        }

        public static explicit operator DamageData(DamageDataBuilder damageDataBuilder)
        {
            return damageDataBuilder.ToDamageData();
        }

        #endregion Public Methods


        #region Public Variables

        public int DamageValue;
        public Transform DamageDealer;

        #endregion Public Variables
    }

    public static class DamageDataBuilderExtenstion
    {
        public static DamageDataBuilder AddOverride(this DamageDataBuilder damageDataBuilder, Unit target,
            List<DamageOverrides> damageOverrides)
        {
            foreach (DamageOverrides damageOverride in damageOverrides)
            {
                if (target.Attributes.Contains(damageOverride.attribute))
                    damageDataBuilder.DamageValue = damageOverride.damageOverrideValue;
            }

            return damageDataBuilder;
        }

        public static DamageDataBuilder AddDamageDealer(this DamageDataBuilder damageDataBuilder,
            Transform damageDealer)
        {
            damageDataBuilder.DamageDealer = damageDealer;
            return damageDataBuilder;
        }
    }
}