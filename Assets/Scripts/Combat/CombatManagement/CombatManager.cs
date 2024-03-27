using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    public class CombatManager : MonoBehaviour
    {
        #region Inspector Variables

        [SerializeField]
        private float timeBetweenRounds;

        [SerializeField]
        private AbstractUnitFactory abstractUnitFactory;

        [SerializeField]
        private AbstractCombatEnumeratorFactory abstractCombatEnumeratorFactory;

        #endregion Inspector Variables

        #region Unity Methods

        private void Start()
        {
            _units = abstractUnitFactory.CreateUnits();
            _units.Shuffle();

            combatIterator = abstractCombatEnumeratorFactory.Get(_units);
        }


        private void FixedUpdate()
        {
            if (Time.time > nextUpdateTime)
            {
                nextUpdateTime = Time.time + timeBetweenRounds;
                SimulationTick();
            }
        }

        private void SimulationTick()
        {
            if (combatIterator.Current != null)
                combatIterator.Current.Tick();

            combatIterator.MoveNext();
        }

        #endregion Unity Methods


        #region Private Variables

        private List<Unit> _units;
        private IEnumerator<Unit> combatIterator;

        private float nextUpdateTime = 0;

        #endregion Private Variables
    }
}