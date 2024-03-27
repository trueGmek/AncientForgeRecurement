﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace AFSInterview.Combat
{
    [CreateAssetMenu(menuName = "Ancient Forge/Combat/Mock Unit Factory")]
    public class MockUnitFactory : AbstractUnitFactory
    {
        [FormerlySerializedAs("parameters"), SerializeField]
        private UnitBlueprint blueprint;

        [SerializeField]
        private GameObject unitPrefab;

        [SerializeField]
        private int numberOfUnitsPerArmy = 3;

        public override List<Unit> CreateUnits(Army blue, Army red)
        {
            List<Unit> units = new();

            SpawnUnits(blue, units);
            SpawnUnits(red, units);

            return units;
        }

        private void SpawnUnits(Army army, ICollection<Unit> allUnits)
        {
            for (int i = 0; i < numberOfUnitsPerArmy; i++)
            {
                Unit unit = InstantiateUnit(unitPrefab, army);
                GenerateUnitName(army, i, unit.gameObject, blueprint.title);
                unit.Initialize(blueprint, army);

                allUnits.Add(unit);
                army.units.Add(unit);
            }
        }
    }
}