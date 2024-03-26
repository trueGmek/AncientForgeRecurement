using TMPro;
using UnityEngine;

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


        private void OnEnable()
        {
            _textMeshProUGUI = FindObjectOfType<TextMeshProUGUI>();
            _lazyCamera = Camera.main;
            _layerMask = LayerMask.GetMask("Item");
        }

        private void Update()
        {
            if (Time.time >= _nextItemSpawnTime)
                SpawnNewItem();

            if (Input.GetMouseButtonDown(0))
                TryPickUpItem();

            if (Input.GetKeyDown(KeyCode.Space))
                inventoryController.SellAllItemsUpToValue(itemSellMaxValue);

            _textMeshProUGUI.text = $"Money: {inventoryController.Money.ToString()}";
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
            Ray ray = _lazyCamera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out RaycastHit hit, 100f, _layerMask) ||
                !hit.collider.TryGetComponent(out IItemHolder itemHolder))
                return;

            Item item = itemHolder.GetItem(true);
            inventoryController.AddItem(item);

            Debug.Log(
                $"Picked up {item.Name} with value of {item.Value.ToString()} and now have {inventoryController.ItemsCount.ToString()} items");
        }


        private TextMeshProUGUI _textMeshProUGUI;
        private Camera _lazyCamera;
        private int _layerMask;

        private float _nextItemSpawnTime;
    }
}