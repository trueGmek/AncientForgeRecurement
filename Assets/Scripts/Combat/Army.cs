using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    public class Army : MonoBehaviour
    {
        [SerializeField]
        private string name;

        [SerializeField]
        private Army opponent;


        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }

        public void NoteDeath(Unit unit)
        {
            units.Remove(unit);

            if (units.Count == 0)
                CombatManager.OnArmyDefeated?.Invoke(this);
        }

        public Army Opponent => opponent;
        public List<Unit> Units => units;


        public Bounds bounds;
        public List<Unit> units;
    }
}