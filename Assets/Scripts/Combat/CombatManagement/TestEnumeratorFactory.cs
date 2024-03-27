using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
    [CreateAssetMenu(menuName = "Ancient Forge/Combat/Test enumerator factory")]
    public class TestEnumeratorFactory : AbstractCombatEnumeratorFactory
    {
        public override IEnumerator<Unit> Get(List<Unit> units)
        {
            units.Shuffle();
            return new CircularEnumerator(units);
        }

        private class CircularEnumerator : IEnumerator<Unit>
        {
            private readonly List<Unit> _list;
            private int _index;

            public CircularEnumerator(List<Unit> list)
            {
                _list = list;
            }

            public bool MoveNext()
            {
                for (int i = _index + 1; i < _list.Count; i++)
                {
                    if (_list[i].IsDead())
                        continue;

                    _index = i;
                    return true;
                }

                Reset();
                return true;
            }

            public void Reset()
            {
                _list.RemoveAll(t => t.IsDead());
                _index = 0;
            }

            public Unit Current => _list[_index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _index = -1;
            }
        }
    }
}