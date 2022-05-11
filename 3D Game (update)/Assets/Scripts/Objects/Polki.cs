using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polki : MonoBehaviour
{
    private bool isOpened;
    [SerializeField] private Animator polka;

    public void Open()
    {
        polka.SetBool("isOpened", isOpened);       
        isOpened = !isOpened;
    }
}
