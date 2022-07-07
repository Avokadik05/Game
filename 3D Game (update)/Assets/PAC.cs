using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PAC : MonoBehaviour
{
    [SerializeField]
    private Image a;

    [SerializeField]
    private Image d;

    [SerializeField]
    private GameObject GamePanel;

    public static bool PACMiniGame = false;
    public static bool PACab = false;
    public static bool PACdb = false;

    [Header("—сылки на обьекты")]
    [SerializeField] 
    private Image loadImg;
    
    [SerializeField] 
    private Text loadText;

    private void Start()
    {
        GamePanel.SetActive(false);
        //StartCoroutine(AsyncLoads());
    }

    public void Update()
    {
        PACGame();
    }

    public void PACGame()
    {
        if (PACMiniGame)
        {
            Time.timeScale = 0f;

            if (Input.GetKeyDown(KeyCode.A) && PACdb == false)
            {
                PACdb = true;
                PACab = false;
                PACd();
            }
            else if (Input.GetKeyDown(KeyCode.D) && PACab == false)
            {
                PACab = true;
                PACdb = false;
                PACa();
            }
        }
    }
    
    public void PACa()
    {
        a.enabled = true;
        d.enabled = false;
    }

    public void PACd()
    {
        d.enabled = true;
        a.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        PACMiniGame = true;
        GamePanel.SetActive(true);
        PACGame();
    }

    /*IEnumerator AsyncLoads()
    {
        AsyncOperation operation =;
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadImg.fillAmount = progress;
            loadText.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }*/
}
