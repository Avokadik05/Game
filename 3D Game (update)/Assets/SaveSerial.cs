using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSerial : MonoBehaviour
{
    private float X, Y, Z;
    private float Xrot, Yrot;
    public Transform player;
    public GameObject testObj;
    public string levelTS;

    DateTime _date;

    public Text test;

    private void Start()
    {
        LoadGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            LoadGame();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ResetData();
        }
        
        /*test.text = "This time " + _date;*/
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        
        /*data.savedInt = intToSave;
        data.savedFloat = floatToSave;
        data.savedBool = boolToSave;
        data.savedBool = boolToSave;*/
        
        X = player.transform.position.x;
        Y = player.transform.position.y;
        Z = player.transform.position.z;
        data.Xs = X;
        data.Ys = Y;
        data.Zs = Z;

        Xrot = player.transform.rotation.x;
        Yrot = player.transform.rotation.y;
        data.Xr = Xrot;
        data.Yr = Yrot;

        if (testObj.activeSelf)
            data.activeObj = true;
        else
            data.activeObj = false;

        levelTS = SceneManager.GetActiveScene().name;
        data.levelName = levelTS;

        /*if (GameObject.FindGameObjectsWithTag("Key").Length == 0)
            print("Hello word");*/

        bf.Serialize(file, data);
        file.Close();

        _date = DateTime.Now;
        
        Debug.Log("Game data saved! Date saved: " + _date);




    }

    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            /*intToSave = data.savedInt;
            floatToSave = data.savedFloat;
            boolToSave = data.savedBool;*/
            
            X = data.Xs;
            Y = data.Ys;
            Z = data.Zs;
            player.transform.position = new Vector3(X, Y, Z);

            Xrot = data.Xr;
            Yrot = data.Yr;
            player.transform.rotation = new Quaternion(Xrot, Yrot, 0, 0);

            if (data.activeObj)
                testObj.SetActive(true);
            else
                testObj.SetActive(false);

            levelTS = data.levelName;

            if (SceneManager.GetActiveScene().name == levelTS)
                print("You are on the current scene");
            else
            {
                SceneManager.LoadScene(levelTS);
                print("You are on another scene, you save in: " + levelTS);
            }
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/MySaveData.dat");
            /*intToSave = 0;
            floatToSave = 0.0f;
            boolToSave = false;*/
            testObj.SetActive(true);
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }


}

[Serializable]
class SaveData
{
    public int savedInt;
    public float savedFloat;
    public bool savedBool;
    public float Xs, Ys, Zs;
    public float Xr, Yr;
    public bool activeObj;
    public string levelName;
    public string savedDate;
}
