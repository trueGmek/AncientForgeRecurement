using System;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Items
{
    [Serializable]
    public class Item
    {
        [SerializeField]
        private string name;

        [SerializeField]
        private int value;

        [SerializeField]
        private List<ItemEffect> itemEffects;

        public string Name => name;
        public int Value => value;

        public Item(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

        public virtual void Use()
        {
            Debug.Log("Using" + Name);

            ApplyItemsEffect();
        }

        private void ApplyItemsEffect()
        {
            foreach (ItemEffect itemEffect in itemEffects)
            {
                itemEffect.ApplyEffect(this);
            }
        }
    }
}