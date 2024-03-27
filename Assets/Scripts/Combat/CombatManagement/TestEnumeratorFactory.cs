using System.Collections;
using System.Collections.Generic;
using AFSInterview.Combat;
using UnityEngine;

[CreateAssetMenu(menuName = "Ancient Forge/Combat/Test enumerator factory")]
public class TestEnumeratorFactory : AbstractCombatEnumeratorFactory
{
    public override IEnumerator<Unit> Get(List<Unit> units)
    {
        units.Shuffle();
        return new RotationEnumerator<Unit>(units);
    }

    private class RotationEnumerator<T> : IEnumerator<T>
    {
        private readonly List<T> _list;
        private int _index;

        public RotationEnumerator(List<T> list)
        {
            _list = list;
        }

        public bool MoveNext()
        {
            if (_index >= _list.Count - 1)
                Reset();
            else
                _index++;

            return true;
        }

        public void Reset()
        {
            _index = 0;
        }

        public T Current => _list[_index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _index = -1;
        }
    }
}