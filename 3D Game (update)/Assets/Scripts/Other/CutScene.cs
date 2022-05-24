using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutScene : MonoBehaviour
{
    [SerializeField]
    private CustomCharacterController controller;
    [SerializeField]
    private CinemachineVirtualCamera cam;

    public void OffController()
    {
        controller.enabled = false;
        cam.enabled = false;
    }

    public void OnController()
    {
        controller.enabled = true;
        cam.enabled = true;
    }
}
