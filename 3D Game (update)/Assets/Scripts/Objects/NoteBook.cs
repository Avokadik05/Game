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
        text.text = "Запись №1 - По дороге сломалась машина, сейчас соберу вещи и пойду пешком. Судя по карте, это не займет много времени. Кроме того, это случилось снова...";
    }

    public void Add2()
    {
        text.text = "Запись №2 - Войдя в дом, никого не было. Я также нашел лист бумаги на столе. Кто такой Анатолий М. А где мама?";
        sound.VoidEventSoundList();
    }

    public void Add3()
    {
        text.text = "Запись №3 - Я очнулся в подвале, вообще не понимаю, что произошло... Но точно знаю, что мне нужно выбираться отсюда и искать маму.";
        sound.VoidEventSoundList();
    }

    public void Add4()
    {
        text.text = "Запись №4 - ";
        sound.VoidEventSoundList();
    }

    public void Add5()
    {
        text.text = "Запись №5 - ";
        sound.VoidEventSoundList();
    }

    public void Add6()
    {
        text.text = "Запись №6 - ";
        sound.VoidEventSoundList();
    }
}
