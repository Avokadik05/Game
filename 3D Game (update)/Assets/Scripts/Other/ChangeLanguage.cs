using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguage : MonoBehaviour
{
    [SerializeField]
    private LangsList lang;

    private void Start()
    {
        lang.Load();
    }

    public void ChangeLang(Dropdown drop)
    {
        LangsList.SetLanguage(drop.value, true);
    }
}
