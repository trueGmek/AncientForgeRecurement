using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    [CreateAssetMenu(menuName = "Ancient Forge/Combat/Unit blueprint")]
    public class UnitBlueprint : ScriptableObject
    {
        public string title;
        public int initialHealth;
        public int armour;
        public int damage;
        public int attackInterval;
        public List<UnitAttribute> attributes;
        public List<DamageOverrides> damageOverrides;
    }
}