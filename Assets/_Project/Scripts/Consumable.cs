using System;
using UnityEngine;

namespace CreativeCoding.InventorySystem
{
    [CreateAssetMenu(fileName = "New Consumable", menuName = "Item/Consumable", order = 0)]
    public class Consumable : Item
    {
        [Header("Consumable Properties")]
        public Effects effects;

        [Flags]
        public enum Effects
        {
            None = 0,
            ModifiesHealth = 1,
            ModifiesSpeed = 2,
            ModifiesDamage = 4
        }
    }
}