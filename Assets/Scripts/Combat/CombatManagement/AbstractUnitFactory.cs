using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AFSInterview.Combat
{
    public abstract class AbstractUnitFactory : ScriptableObject
    {
        public abstract List<Unit> CreateUnits(Army blue, Army red);


        protected static void GenerateUnitName(Object army, int i, Object unit, string title)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append($"{army.name} {i}: {title} ");

            unit.name = stringBuilder.ToString();
        }

        protected static Unit InstantiateUnit(GameObject unitPrefab, Army army)
        {
            Bounds spawnAreaBounds = army.bounds;

            Vector3 position = new(
                Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x),
                Random.Range(spawnAreaBounds.min.y, spawnAreaBounds.max.y),
                Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z)
            );

            GameObject unitGameObject = Instantiate(unitPrefab, position, Quaternion.identity, army.transform);

            return unitGameObject.GetComponent<Unit>();
        }
    }
}