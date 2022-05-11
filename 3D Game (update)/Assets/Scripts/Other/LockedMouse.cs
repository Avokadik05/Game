using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedMouse : MonoBehaviour
{

    void Start()
    {
        //При запуске игры, курсор изчезает и не мешает (В юнити его можно обратно вкл (ESC/ЛКМ))
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //CursorUnLock();
    }

    private void CursorUnLock()
    {
        //При нажатии "Кнопки", курсор обратно появляется и функциануриует, подойдёт для EscMenu
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
