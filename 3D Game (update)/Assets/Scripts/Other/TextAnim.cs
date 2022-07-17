using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextAnim : MonoBehaviour
{
    [SerializeField]
    private Text _textObj;
    
    private string _text;
    
    void Start()
    {
        _text = _textObj.text;
        _textObj.text = "";
    }

    IEnumerator TextCoroutine()
    {
        foreach (char abc in _text)
        {
            _textObj.text += abc;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void Anim()
    {
        StartCoroutine(TextCoroutine());
    }
}
