using CreativeCoding.InventorySystem;
using System;
using UnityEngine;

namespace CreativeCoding.PlayerSystem
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Inventory")]
        [SerializeField] private Inventory inventory;

        private void Start()
        {
            InventoryUI.Instance.UpdateInventory(inventory);
        }
    }

    [Serializable]
    public class Inventory
    {
        public int keys;
        public int applePies;
        public int pants;
        public int swords;
        public int shields;
    }
}