using System;
using UnityEngine;

namespace CreativeCoding.InventorySystem
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Equipment/Weapon", order = 0)]
    public class Weapon : Equipment
    {
        [Header("Weapon Properties")]
        public float damage = 10;
        public float range = 1;
    }
}