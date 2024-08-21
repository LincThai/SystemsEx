using System;
using UnityEngine;

namespace CreativeCoding.InventorySystem
{
    [CreateAssetMenu(fileName = "New Key", menuName = "Item/Key", order = 0)]
    public class Key : Item
    {
        [Header("Key Properties")]
        public LockType lockType;

        [Flags]
        public enum LockType
        {
            None = 0,
            Rusty = 1,
            Gold = 2,
            Silver = 4
        }
    }
}
