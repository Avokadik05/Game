using UnityEngine;

namespace Other.Inventory
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] 
        private UnityEngine.UI.Image _icon;

        [SerializeField] 
        private UnityEngine.UI.Image _backgroundImage;

        [SerializeField] 
        private Color _selectableColor;
        
        [SerializeField] 
        private Color _unselectableColor;
        
        [SerializeField] 
        private int _numberCell;

        [SerializeField] 
        private InventoryPanel _inventoryPanel;
        
        private void OnEnable()
        {
            _inventoryPanel.Refresh += Refresh;
        }

        private void OnDisable()
        {
            _inventoryPanel.Refresh -= Refresh;
        }

        public void Selectable()
        {
            _backgroundImage.color = _selectableColor;
        }

        public void Unselectable()
        {
            _backgroundImage.color = _unselectableColor;
        }
        private void Refresh()
        {
            var item = Item();
            
            print(item);
            
            if (item)
            {
                _icon.gameObject.SetActive(true);
                _icon.sprite = item.Icon;
            }
            else
            {
                _icon.gameObject.SetActive(false);
                _icon.sprite = null;
            }
        }

        private ItemData Item() => 
            _inventoryPanel.ItemDatas[_numberCell];

        private void UseItem()
        {
            if (Item())
                print("UseItem");
        }
    }
}
