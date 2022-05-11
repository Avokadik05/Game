using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [Header("Название загружаемой сцены")]
    public string sceneID;
    [Header("Ссылки на обьекты")]
    [SerializeField] private Image loadImg;
    [SerializeField] private Text loadText;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadImg.fillAmount = progress;
            loadText.text = string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
}
