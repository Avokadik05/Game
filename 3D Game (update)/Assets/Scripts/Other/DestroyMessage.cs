using UnityEngine;
using UnityEngine.UI;

public class DestroyMessage : MonoBehaviour
{
    [SerializeField] 
    private float time;

    [SerializeField]
    private Text _itemText;
    void Update()
    {
        Destroy(_itemText, time);
    }
}
