using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    //Abstract Factory Pattern
    public abstract class AbstractCombatEnumeratorFactory : ScriptableObject
    {
        public abstract IEnumerator<Unit> Get(List<Unit> units);
    }
}