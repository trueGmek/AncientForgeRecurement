using System;
using UnityEngine;

namespace AFSInterview.Items
{
    public abstract class ItemEffect : ScriptableObject
    {
        internal abstract void ApplyEffect(Item owner);

        protected readonly Lazy<InventoryController> LazyInventoryController =
            new(() => FindObjectOfType<InventoryController>());
    }
}