using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Items
{
    [CreateAssetMenu(menuName = "Ancient Forge/Item Effects/Unwrap items")]
    public class UnwrapItemsEffect : ItemEffect
    {
        [SerializeField]
        private List<Item> items;

        internal override void ApplyEffect(Item owner)
        {
            foreach (Item item in items)
            {
                LazyInventoryController.Value.AddItem(item);
            }
        }
    }
}