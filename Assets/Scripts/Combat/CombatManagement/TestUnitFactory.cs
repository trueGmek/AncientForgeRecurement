using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    [CreateAssetMenu(menuName = "Ancient Forge/Combat/Test Unit Factory")]
    public class TestUnitFactory : AbstractUnitFactory
    {
        public GameObject unitPrefab;

        public override List<Unit> CreateUnits(Army blue, Army red)
        {
            List<Unit> units = new();

            SpawnUnits(blue, units);

            SpawnUnits(red, units);

            return units;
        }

        private void SpawnUnits(Army army, List<Unit> units)
        {
            for (int i = 0; i < 3; i++)
            {
                Unit unit = InstantiateUnit(army);

                unit.army = army;
                unit.name = $"{army.name} {i}";
                unit.gameObject.name = unit.name;

                units.Add(unit);
                army.units.Add(unit);
            }
        }

        private Unit InstantiateUnit(Army army)
        {
            Bounds spawnAreaBounds = army.bounds;

            Vector3 position = new(
                Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x),
                0f,
                Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z)
            );

            GameObject unitGameObject = Instantiate(unitPrefab, position, Quaternion.identity, army.transform);

            return unitGameObject.GetComponent<Unit>();
        }
    }
}