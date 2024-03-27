using System;
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

        [SerializeField]
        private Army blue;

        [SerializeField]
        private Army red;

        #endregion Inspector Variables

        #region Unity Methods

        private void OnEnable()
        {
            OnArmyDefeated += NoteArmyDefeated;
        }

        private void OnDisable()
        {
            OnArmyDefeated -= NoteArmyDefeated;
        }

        private void Start()
        {
            _units = abstractUnitFactory.CreateUnits(blue, red);
            isCombatInProgress = true;

            combatIterator = abstractCombatEnumeratorFactory.Get(_units);
        }


        private void FixedUpdate()
        {
            if (Time.time > nextUpdateTime && isCombatInProgress)
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

        private void NoteArmyDefeated(Army army)
        {
            isCombatInProgress = false;
            Debug.Log($"{army.name} army lost");
        }

        #endregion Unity Methods


        #region Private Variables

        private List<Unit> _units;
        private IEnumerator<Unit> combatIterator;
        private bool isCombatInProgress;

        private float nextUpdateTime = 0;

        #endregion Private Variables

        #region Public Events

        public static Action<Army> OnArmyDefeated;

        #endregion Public Events
    }
}