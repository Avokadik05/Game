using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    private float X, Y, Z;
    private Transform player;
    public GameObject newGamePanel;
    public Button nextButton;
    public bool isDesKey;
    [SerializeField]
    private GameObject key;
    public UnityEvent _save;

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
    public void Save()
    {
        PlayerPrefs.SetFloat("PosX", X);
        PlayerPrefs.SetFloat("PosY", Y);
        PlayerPrefs.SetFloat("PosZ", Z);
        PlayerPrefs.SetInt("DesKey", isDesKey ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        CheckPosition();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("PosX"))
        {
            X = PlayerPrefs.GetFloat("PosX");
        }
        else
        {
            X = -70.942f;
        }
        
        if (PlayerPrefs.HasKey("PosY"))
        {
            Y = PlayerPrefs.GetFloat("PosY");
        }
        else
        {
            Y = 0.01340663f;
        }

        if (PlayerPrefs.HasKey("PosZ"))
        {
            Z = PlayerPrefs.GetFloat("PosZ");
        }
        else
        {
            Z = 49.154f;
        }
        player.transform.position = new Vector3(X, Y, Z);

        if (PlayerPrefs.HasKey("DesKey"))
        {
            isDesKey = PlayerPrefs.GetInt("DesKey") == 1;
        }
    }

    public void Delete()
    {
        X = -70.942f;
        Y = 0.01340663f;
        Z = 49.154f;
        isDesKey = false;
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        PlayerPrefs.DeleteKey("PosZ");
        PlayerPrefs.DeleteKey("DesKey");
    }

    public void CheckingSave()
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

    public void CheckPosition()
    {
        X = player.transform.position.x;
        Y = player.transform.position.y;
        Z = player.transform.position.z;

        if (Input.GetKeyDown(KeyCode.F5))
        {
            _save.Invoke();
            print("Успешно!");
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            Load();
        }

    }
}