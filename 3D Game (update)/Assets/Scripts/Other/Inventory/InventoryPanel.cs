using System;
using UnityEngine;

namespace Other.Inventory
{
    public class InventoryPanel : MonoBehaviour
    {
        [SerializeField] 
        private Transform _target;

        [SerializeField] 
        private Transform _container;
        
        [SerializeField] 
        private InventoryData _inventoryData;

        [SerializeField] 
        private Cell[] _cells = new Cell[6];
        
        private ItemData[] _itemDatas => _inventoryData.ItemDatas;
        private int? _currentCellNumber;
        private int _currentNumberCell = 0;
        
        public event Action Refresh;
        public ItemData CurrentItem => _itemDatas[_currentNumberCell];
        public ItemData[] ItemDatas => _itemDatas;

        private void Start()
        {
            Reset(); //очищает инвентарь при запуске
            Refresh?.Invoke();
            ChouseCell(0);
        }

        private void Update()
        {
            Input();
        }

        private void Input()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
                ChouseCell(0);

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
                ChouseCell(1);

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
                ChouseCell(2);

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
                ChouseCell(3);

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha5))
                ChouseCell(4);

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha6))
                ChouseCell(5);

            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
                Drop();
        }

        public bool TryAddItem(ItemData item)
        {
            for (int i = 0; i < _itemDatas.Length; i++)
            {
                if (!_itemDatas[i])
                {
                    _itemDatas[i] = item;
                    Refresh?.Invoke();
                    return true;
                }
            }
            
            print("Инвентарь переполнен");
            return false;
        }
        
        private void ChouseCell(int numberCell)
        {
            foreach (var cell in _cells) 
                cell.Unselectable();

            _cells[numberCell].Selectable();
            _currentNumberCell = numberCell;
        }

        public void Reset() => 
            _inventoryData.ItemDatas = new ItemData[6];

        private void Drop()
        {
            //print("Drop");
            
            if (CurrentItem)
            {
                Instantiate(CurrentItem.Prefab, _target.position, Quaternion.identity, _container);
                _itemDatas[_currentNumberCell] = null;
                Refresh?.Invoke();
            }
        }
    }
}