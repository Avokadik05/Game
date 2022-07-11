using UnityEngine;

public class Notes : MonoBehaviour
{
    [SerializeField] private GameObject notePanel;
    public EventSound sound;
    public GameObject cameraTargget;
    public bool isNote = false;

    private void Start()
    {
        notePanel.SetActive(false);
    }

    public void OnNote()
    {
        isNote = true;
        Time.timeScale = 0f;
        cameraTargget.SetActive(false);
        notePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        sound.VoidEventSoundList();

    }

    public void ExitNote()
    {
        isNote = false;
        Time.timeScale = 1f;
        cameraTargget.SetActive(true);
        notePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}