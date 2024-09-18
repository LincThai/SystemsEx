using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;
using Codice.CM.Common.Merge;
using System;
using System.Threading.Tasks;
using CreativeCoding.PlayerSystem;



namespace CreativeCoding.InventorySystem
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Item currentItem;

        [SerializeField] private Button mainButton;

        [SerializeField] private TMP_Text quantityText;
        [SerializeField] private Image itemImage;

        private AsyncOperationHandle<Sprite> thumbnailHandle;
        private AsyncOperationHandle<GameObject> loadedMeshHandle;

        public static event Action<Item> OnItemSpawned;

        private void Awake()
        {
            mainButton.onClick.AddListener(OnMainButtonClicked);
        }

        private void OnEnable()
        {
            InventoryUI.Instance.hideEvent += OnHide;
            OnItemSpawned += ItemSpawned;
        }

        private void OnDisable()
        {
            InventoryUI.Instance.hideEvent -= OnHide;
            OnItemSpawned -= ItemSpawned;
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

        private async void OnMainButtonClicked()
        {
            Debug.Log("is clicked");

            // check to see if we have addressable key exists;
            if (currentItem.itemMesh.RuntimeKeyIsValid())
            {
                // check to see if the mesh has loaded or not
                if (!loadedMeshHandle.IsValid())
                {
                    loadedMeshHandle = currentItem.itemMesh.InstantiateAsync(PlayerController.instance.Container);
                    //await loadedmeshHandle.task;
                        
                    while (!loadedMeshHandle.IsDone)
                    {
                        await Task.Delay(16);
                    }

                    if (loadedMeshHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        OnLoadedMesh();
                    }
                }
                else // we have loaded the mesh
                {
                    OnLoadedMesh();
                }
            }
        }

        private void OnLoadedMesh()
        {
            Debug.Log("Loaded Mesh");
            loadedMeshHandle.Result.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            OnItemSpawned?.Invoke(currentItem);
        }

        private void ItemSpawned(Item item)
        {
            if (item == currentItem)
            {
                
            }
            else // new item spawned is not this item.
            {
                if (loadedMeshHandle.IsValid())
                {
                    Addressables.ReleaseInstance(loadedMeshHandle.Result);
                }
            }
        }
    }
}