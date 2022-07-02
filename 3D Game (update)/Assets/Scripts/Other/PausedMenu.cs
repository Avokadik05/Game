using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    [Header("—сылки на объекты")]
    [SerializeField]
    private GameObject inventory;
    [SerializeField]
    private GameObject inventory2;
    [SerializeField]
    private GameObject pausedMenu;
    [SerializeField]
    private GameObject exitMenu;
    [SerializeField]
    private GameObject settingMenu;
    [SerializeField]
    private GameObject crosshair;
    [SerializeField]
    private GameObject staminaSlider;
    [SerializeField]
    private CinemachineBrain cameraTargget;
    
    [Header("Other")]
    public static bool GameIsPause = false;

    private void Start()
    {
        pausedMenu.SetActive(false);
        settingMenu.SetActive(false);
        exitMenu.SetActive(false);
    }

    private void Update()
    {
        ActiveMenu();
    }
    void ActiveMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        GameIsPause = false;
        pausedMenu.SetActive(false);
        crosshair.SetActive(true);
        inventory.SetActive(true);
        inventory2.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        cameraTargget.enabled = true;
        staminaSlider.SetActive(true);
    }

    public void Pause()
    {
        GameIsPause = true;
        pausedMenu.SetActive(true);
        crosshair.SetActive(false);
        inventory.SetActive(false);
        inventory2.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        cameraTargget.enabled = false;
        staminaSlider.SetActive(false);
    }

    public void PauseMenuSetting()
    {
        settingMenu.SetActive(true);
        crosshair.SetActive(false);
        inventory.SetActive(false);
        inventory2.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        cameraTargget.enabled = false;
        staminaSlider.SetActive(false);
    }

    public void ExitMenuSetting()
    {
        settingMenu.SetActive(false);
    }

    public void StartGames()
    {
        SceneManager.LoadScene("Loading");
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void InteractiveOptions()
    {
        crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        cameraTargget.enabled = false;
        staminaSlider.SetActive(false);
    }
}
