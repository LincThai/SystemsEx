using System;
using UnityEngine;

namespace CreativeCoding.InventorySystem
{
    [CreateAssetMenu(fileName = "New Armour", menuName = "Item/Equipment/Armour", order = 0)]
    public class Armour : Equipment
    {
        [Header("Armour Properties")]
        public float defense = 10;
    }
}