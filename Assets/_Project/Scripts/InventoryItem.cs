using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;



namespace CreativeCoding.InventorySystem
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Item currentItem;

        [SerializeField] private TMP_Text quantityText;
        [SerializeField] private Image itemImage;

        private AsyncOperationHandle<Sprite> thumbnailHandle;

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

        public async void Initialize(Item newItem, int quantity)
        {
            currentItem = newItem;
            name = newItem.itemName;

            quantityText.text = quantity.ToString();

            itemImage.enabled = false;

            // unload loaded if it exists
            if (thumbnailHandle.IsValid())
                Addressables.Release(thumbnailHandle);

            if (newItem.thumbnail.RuntimeKeyIsValid())
            {
                thumbnailHandle = Addressables.LoadAssetAsync<Sprite>(newItem.thumbnail);
                await thumbnailHandle.Task;

                if (thumbnailHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    itemImage.sprite = thumbnailHandle.Result;
                    itemImage.enabled = true;
                }
            }
        }
    }
}