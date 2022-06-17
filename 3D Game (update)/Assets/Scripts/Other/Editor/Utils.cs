using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Utils
{
    
    [MenuItem("Utils/Clear Prefs")]
    public static void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Успешно!");
    }
}
