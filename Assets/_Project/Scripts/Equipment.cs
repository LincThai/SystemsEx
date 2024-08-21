using System;
using UnityEngine;

namespace CreativeCoding.InventorySystem
{
    [Serializable]
    public class Equipment : Item
    {
        [Range(0.0f, 100.0f)]
        public float durability = 50;
    }
}