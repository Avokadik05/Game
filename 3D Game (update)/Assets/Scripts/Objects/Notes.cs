using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    [SerializeField] private GameObject notePanel;
    [SerializeField] private GameObject Player;
    public EventSound sound;
    public GameObject cameraTargget;

    private void Start()
    {
        notePanel.SetActive(false);
    }

    public void OnNote()
    {
        notePanel.SetActive(true);
        cameraTargget.SetActive(false);
        Time.timeScale = 0f;
        Player.SetActive(false);
        sound.VoidEventSoundList();

    }

    public void ExitNote()
    {
        notePanel.SetActive(false);
        cameraTargget.SetActive(true);
        Time.timeScale = 1f;
        Player.SetActive(true);
    }
}
