using CreativeCoding.InventorySystem;
using System;
using UnityEngine;

namespace CreativeCoding.PlayerSystem
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance {  get; private set; }

        [Header("Inventory")]
        [SerializeField] private Inventory inventory;
        public Inventory Inventory => inventory;

        private void Awake()
        {
            instance = this;
        }

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