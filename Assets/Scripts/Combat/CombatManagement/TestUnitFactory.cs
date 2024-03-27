using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AFSInterview.Combat
{
    [CreateAssetMenu(menuName = "Ancient Forge/Combat/Test Unit Factory")]
    public class TestUnitFactory : AbstractUnitFactory
    {
        [SerializeField]
        private UnitParameters parameters;

        public GameObject unitPrefab;

        public override List<Unit> CreateUnits(Army blue, Army red)
        {
            List<Unit> units = new();

            SpawnUnits(blue, units);

            SpawnUnits(red, units);

            return units;
        }

        private void SpawnUnits(Army army, List<Unit> allUnits)
        {
            for (int i = 0; i < 3; i++)
            {
                Unit unit = InstantiateUnit(army);
                GenerateUnitName(army, i, unit.gameObject, parameters.attributes);
                unit.Initialize(parameters, army);

                allUnits.Add(unit);
                army.units.Add(unit);
            }
        }

        private static void GenerateUnitName(Object army, int i, GameObject unit, List<UnitAttribute> attributes)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append($"{army.name} {i} ");
            foreach (UnitAttribute attribute in attributes)
            {
                stringBuilder.Append(attribute.name).Append(" ");
            }

            unit.name = stringBuilder.ToString();
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