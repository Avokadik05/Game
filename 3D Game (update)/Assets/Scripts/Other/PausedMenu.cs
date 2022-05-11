using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject inventory2;
    public GameObject pausedMenu;
    public GameObject exitMenu;
    public GameObject settingMenu;
    public GameObject crosshair;
    public GameObject staminaSlider;
    public CinemachineBrain cameraTargget;
    [SerializeField] private KeyCode keyPausedMenu;
    bool isPausedMenu = false;

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
        if (Input.GetKeyDown(keyPausedMenu)) 
        {
            isPausedMenu = !isPausedMenu;
        }

        if (isPausedMenu)
        {
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
        else
        {
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
    }

    public void PauseMenuContinue()
    {
        isPausedMenu = false;
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
