using System;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    [CreateAssetMenu(menuName = "Ancient Forge/Combat/Manual unit factory")]
    public class ManualUnitFactory : AbstractUnitFactory
    {
        #region Public Variables

        [SerializeField]
        private List<Group> blueArmyBlueprint;

        [SerializeField]
        private List<Group> redArmyBlueprint;

        [SerializeField]
        private GameObject unitPrefab;

        #endregion Public Variables


        #region Public Methods

        public override List<Unit> CreateUnits(Army blue, Army red)
        {
            List<Unit> units = new();

            IEnumerable<Unit> blueUnits = SpawnUnits(blue, blueArmyBlueprint);
            IEnumerable<Unit> redUnits = SpawnUnits(red, redArmyBlueprint);

            units.AddRange(blueUnits);
            units.AddRange(redUnits);

            return units;
        }

        private IEnumerable<Unit> SpawnUnits(Army army, List<Group> groups)
        {
            List<Unit> createdUnits = new();
            foreach (Group group in groups)
            {
                for (int i = 0; i < group.amount; i++)
                {
                    Unit unit = InstantiateUnit(unitPrefab, army);

                    GenerateUnitName(army, i, unit.gameObject, group.blueprint.title);
                    unit.Initialize(group.blueprint, army);

                    createdUnits.Add(unit);
                    army.units.Add(unit);
                }
            }

            return createdUnits;
        }

        #endregion Public Methods


        #region Public Types

        [Serializable]
        public struct Group
        {
            [Min(1)]
            public int amount;

            public UnitBlueprint blueprint;
        }

        #endregion Public Types
    }
}