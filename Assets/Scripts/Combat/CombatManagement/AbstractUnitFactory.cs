using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    public abstract class  AbstractUnitFactory : ScriptableObject
    {
        public abstract List<Unit> CreateUnits();
    }
}