using UnityEngine;
using UnityEngine.UI;

public class NoteBook : MonoBehaviour
{
    [SerializeField] private GameObject notePanel;
    [SerializeField] private Text text;
    public static bool isNoteBook = false;
    [SerializeField] private bool isNoteBookLock = false;
    public EventSound sound;
    public GameObject cameraTargget;

    private void Start()
    {
        notePanel.SetActive(false);
        Add();
    }

    private void Update()
    {
        OnOff();
    }

    public void OnNote()
    {
        isNoteBook = true;
        Time.timeScale = 0f;
        cameraTargget.SetActive(false);
        notePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


    }

    public void ExitNote()
    {
        isNoteBook = false;
        Time.timeScale = 1f;
        cameraTargget.SetActive(true);
        notePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnOff()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (isNoteBookLock)
            {
                print("Locked");
            }
            else
            {
                if (isNoteBook)
                {
                    ExitNote();
                }
                else
                {
                    OnNote();
                }
            }
        }
    }
    
    public void Add()
    {
        text.text = "������ �1 - �� ������ ��������� ������, ������ ������ ���� � ����� ������. ���� �� �����, ��� �� ������ ����� �������. ����� ����, ��� ��������� �����...";
    }

    public void Add2()
    {
        text.text = "������ �2 - ����� � ���, ������ �� ����. � ����� ����� ���� ������ �� �����. ��� ����� �������� �. � ��� ����?";
        sound.VoidEventSoundList();
    }

    public void Add3()
    {
        text.text = "������ �3 - � ������� � �������, ������ �� �������, ��� ���������... �� ����� ����, ��� ��� ����� ���������� ������ � ������ ����.";
        sound.VoidEventSoundList();
    }

    public void Add4()
    {
        text.text = "������ �4 - ";
        sound.VoidEventSoundList();
    }

    public void Add5()
    {
        text.text = "������ �5 - ";
        sound.VoidEventSoundList();
    }

    public void Add6()
    {
        text.text = "������ �6 - ";
        sound.VoidEventSoundList();
    }
}
