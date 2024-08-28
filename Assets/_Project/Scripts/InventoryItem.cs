using UnityEngine;

namespace CreativeCoding.InventorySystem
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Item currentItem;

        private void OnEnable()
        {
            InventoryUI.Instance.hideEvent += OnHide;
        }

        private void OnDisable()
        {
            InventoryUI.Instance.hideEvent -= OnHide;
        }

        private void OnHide()
        {
            if (gameObject.activeSelf)
                InventoryUI.Instance.InventoryItemPool.Release(this);
        }

        public void Initialize(Item newItem, int quantity)
        {
            currentItem = newItem;
            name = newItem.itemName;
        }
    }
}