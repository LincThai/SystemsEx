using System;
using UnityEngine;
using UnityEngine.Pool;
using CreativeCoding.PlayerSystem;

namespace CreativeCoding.InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        public static InventoryUI Instance;

        [Header("Inventory Item Info")]
        [SerializeField] private Key skeletonKeyInfo;
        [SerializeField] private Consumable applePieInfo;
        [SerializeField] private Armour pantsInfo;
        [SerializeField] private Weapon swordInfo;
        [SerializeField] private Weapon shieldInfo;

        private ObjectPool<InventoryItem> inventoryItemPool;
        public ObjectPool<InventoryItem> InventoryItemPool => inventoryItemPool;

        [SerializeField] private InventoryItem itemPrefab;
        [SerializeField] private Transform itemParent;

        public event Action hideEvent;

        private void Awake()
        {
            Instance = this;
            CreatePool();
        }

        private void CreatePool()
        {
            inventoryItemPool = new ObjectPool<InventoryItem>(() =>
            {
                InventoryItem item = Instantiate(itemPrefab, itemParent);
                return item;
            },
            item => { item.gameObject.SetActive(true); },
            item => { item.gameObject.SetActive(false); },
            item => { Destroy(item.gameObject); },
            false, 5, 5);
        }

        [ContextMenu("Update Inventory")]

        private void UpdateIventory()
        {
            UpdateInventory(PlayerController.instance.Inventory);
        }

        public void UpdateInventory(Inventory inventory)
        {
            hideEvent?.Invoke();

            inventoryItemPool.Get(out InventoryItem keyItem);
            keyItem.Initialize(skeletonKeyInfo, inventory.keys);

            inventoryItemPool.Get(out InventoryItem applePieItem);
            applePieItem.Initialize(applePieInfo, inventory.applePies);

            inventoryItemPool.Get(out InventoryItem swordItem);
            swordItem.Initialize(swordInfo, inventory.swords);

            inventoryItemPool.Get(out InventoryItem shieldItem);
            shieldItem.Initialize(shieldInfo, inventory.shields);

            inventoryItemPool.Get(out InventoryItem pantsItem);
            pantsItem.Initialize(pantsInfo, inventory.pants);
        }
    }
}