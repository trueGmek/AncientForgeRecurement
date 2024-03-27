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

            _combatIterator = abstractCombatEnumeratorFactory.Get(_units);

            _isCombatInProgress = true;
        }


        private void FixedUpdate()
        {
            if (Time.time > nextUpdateTime && _isCombatInProgress)
            {
                nextUpdateTime = Time.time + timeBetweenRounds;

                SimulationTick();
            }
        }

        private void SimulationTick()
        {
            if (_combatIterator.Current != null)
                _combatIterator.Current.Tick();

            _combatIterator.MoveNext();
        }

        private void NoteArmyDefeated(Army army)
        {
            _isCombatInProgress = false;
            Debug.Log($"{army.name} army lost");
        }

        #endregion Unity Methods


        #region Private Variables

        private List<Unit> _units;
        private IEnumerator<Unit> _combatIterator;
        private bool _isCombatInProgress;

        private float nextUpdateTime;

        #endregion Private Variables

        #region Public Events

        public static Action<Army> OnArmyDefeated;

        #endregion Public Events
    }
}