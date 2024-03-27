using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    public abstract class AbstractCombatEnumeratorFactory : ScriptableObject
    {
        public abstract IEnumerator<Unit> Get(List<Unit> units);
    }
}