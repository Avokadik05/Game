using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("Настройки UI")]
    public Text gameNameText;
    [SerializeField]
    private string gameName;
    public Text gameVersionText;
    [SerializeField]
    private string gameVersion;

    void Start()
    {
        GameUISetting();
    }
    public void GameUISetting()
    {
        gameVersionText.text = gameVersion;
        gameNameText.text = gameName;
    }


}