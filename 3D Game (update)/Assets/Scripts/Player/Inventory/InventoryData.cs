using UnityEngine;

namespace Other.Inventory
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Data/Inventory", order = 152)]
    public class InventoryData : ScriptableObject
    {
        public ItemData[] ItemDatas = new ItemData[6];
    }
}