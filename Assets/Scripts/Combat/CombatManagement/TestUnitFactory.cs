using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    [CreateAssetMenu(menuName = "Ancient Forge/Combat/Test Unit Factory")]
    public class TestUnitFactory : AbstractUnitFactory
    {
        public override List<Unit> CreateUnits()
        {
            List<Unit> units = new List<Unit>();

            for (int i = 0; i < 5; i++)
            {
                Unit unit = CreateUnit();
                unit.name = $"A {i}";

                units.Add(unit);
            }

            for (int i = 0; i < 5; i++)
            {
                Unit unit = CreateUnit();
                unit.name = $"B {i}";

                units.Add(unit);
            }


            return units;
        }

        private Unit CreateUnit()
        {
            GameObject unitGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            return unitGameObject.AddComponent<Unit>();
        }
    }
}