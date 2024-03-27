using UnityEngine;

namespace AFSInterview.Combat
{
    public class DamageData
    {
        public readonly int DamageValue;
        public readonly Transform DamageDealer;


        public DamageData(int damageValue, Transform damageDealer)
        {
            DamageValue = damageValue;
            DamageDealer = damageDealer;
        }
    }
}