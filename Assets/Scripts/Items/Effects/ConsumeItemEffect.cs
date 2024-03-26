using UnityEngine;

namespace AFSInterview.Items
{
    [CreateAssetMenu(menuName = "Ancient Forge/Item Effects/Consume")]
    public class ConsumeItemEffect : ItemEffect
    {
        internal override void ApplyEffect(Item owner)
        {
            LazyInventoryController.Value.RemoveItem(owner);
        }
    }
}