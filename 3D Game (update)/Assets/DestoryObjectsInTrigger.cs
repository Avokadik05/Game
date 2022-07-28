using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObjectsInTrigger : MonoBehaviour
{
    [SerializeField]
    private Light _flash;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(_flash, 2f);
    }
}
