using UnityEngine;

namespace Other.Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Data/Item", order = 151)]
    public class ItemData : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public GameObject Prefab;
    }
}