using UnityEngine;

namespace AFSInterview.Items
{
    [CreateAssetMenu(menuName = "Ancient Forge/Item Effects/Add money")]
    public class MoneyItemEffect : ItemEffect
    {
        [SerializeField]
        private int value;

        internal override void ApplyEffect(Item owner)
        {
            LazyInventoryController.Value.AddMoney(value);
        }
    }
}