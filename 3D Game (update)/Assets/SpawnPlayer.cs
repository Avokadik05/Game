using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform container;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(player);
        Instantiate(player, container.position, Quaternion.identity);
    }
}
