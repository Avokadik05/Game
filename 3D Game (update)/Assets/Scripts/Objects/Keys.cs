using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public bool isKey = false;

    public void Key()
    {
        isKey = !isKey;
    }
}