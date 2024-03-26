using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AFSInterview.Items
{
    public class ItemsManager : MonoBehaviour
    {
        [SerializeField]
        private InventoryController inventoryController;

        [SerializeField]
        private int itemSellMaxValue;

        [SerializeField]
        private Transform itemSpawnParent;

        [SerializeField]
        private GameObject itemPrefab;

        [SerializeField]
        private BoxCollider itemSpawnArea;

        [SerializeField]
        private float itemSpawnInterval;


        private void Update()
        {
            if (Time.time >= _nextItemSpawnTime)
                SpawnNewItem();

            if (Input.GetMouseButtonDown(0))
                TryPickUpItem();

            if (Input.GetKeyDown(KeyCode.Space))
                inventoryController.SellAllItemsUpToValue(itemSellMaxValue);

            _textMeshProUGUI.Value.text = $"Money: {inventoryController.Money.ToString()}";
        }


        private void SpawnNewItem()
        {
            _nextItemSpawnTime = Time.time + itemSpawnInterval;

            Bounds spawnAreaBounds = itemSpawnArea.bounds;
            Vector3 position = new(
                Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x),
                0f,
                Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z)
            );

            Instantiate(itemPrefab, position, Quaternion.identity, itemSpawnParent);
        }

        private void TryPickUpItem()
        {
            Ray ray = _lazyCamera.Value.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out RaycastHit hit, 100f, _layerMask) ||
                !hit.collider.TryGetComponent(out IItemHolder itemHolder))
                return;

            Item item = itemHolder.GetItem(true);
            inventoryController.AddItem(item);

            Debug.Log(
                $"Picked up {item.Name} with value of {item.Value.ToString()} and now have {inventoryController.ItemsCount.ToString()} items");
        }


        private readonly Lazy<TextMeshProUGUI> _textMeshProUGUI = new(FindObjectOfType<TextMeshProUGUI>);
        private readonly Lazy<Camera> _lazyCamera = new(Camera.main);
        private readonly int _layerMask = LayerMask.GetMask("Item");

        private float _nextItemSpawnTime;
    }
}