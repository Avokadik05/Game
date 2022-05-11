using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    private float X, Y, Z;
    private Transform player;
    public GameObject newGamePanel;
    public Button nextButton;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        Load();
        newGamePanel.SetActive(false);

        if (PlayerPrefs.HasKey("PosX") || PlayerPrefs.HasKey("PosY") || PlayerPrefs.HasKey("PosZ"))
        {
            nextButton.interactable = true;
        }
        else
        {
            nextButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        X = player.transform.position.x;
        Y = player.transform.position.y;
        Z = player.transform.position.z;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("PosX", X);
        PlayerPrefs.SetFloat("PosY", Y);
        PlayerPrefs.SetFloat("PosZ", Z);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("PosX"))
        {
            X = PlayerPrefs.GetFloat("PosX");
        }
        else
        {
            X = 0;
        }
        
        if (PlayerPrefs.HasKey("PosY"))
        {
            Y = PlayerPrefs.GetFloat("PosY");
        }
        else
        {
            Y = 0;
        }

        if (PlayerPrefs.HasKey("PosZ"))
        {
            Z = PlayerPrefs.GetFloat("PosZ");
        }
        else
        {
            Z = 0;
        }
        player.transform.position = new Vector3(X, Y, Z);
    }

    public void Delete()
    {
        X = 0;
        Y = 0;
        Z = 0;
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        PlayerPrefs.DeleteKey("PosZ");
    }

    public void ProverkaNaSave()
    {
        if (PlayerPrefs.HasKey("PosX") || PlayerPrefs.HasKey("PosY") || PlayerPrefs.HasKey("PosZ"))
        {
            newGamePanel.SetActive(true);
        }
        else
        {
            newGamePanel.SetActive(false);
            SceneManager.LoadScene("Loading");
        }
    }
}