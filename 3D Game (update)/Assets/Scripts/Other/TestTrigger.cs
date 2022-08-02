using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestTrigger : MonoBehaviour
{
    [SerializeField]
    private SaveSystem _ss;

    [SerializeField]
    private CyberpunkGlitchFilter _cgf;

    [SerializeField]
    private bool _RGBLab;

    private void Start()
    {
        if (_RGBLab)
        {
            StartCoroutine(GlitchOff());
        }
        else
        {
            _cgf.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Glitch());
    }

    IEnumerator Glitch()
    {
        _cgf.enabled = true;

        yield return new WaitForSeconds(2f);

        _ss.Save();

        SceneManager.LoadScene("Labyrinth 1");
    }

    IEnumerator GlitchOff()
    {
        _cgf.enabled = true;

        yield return new WaitForSeconds(2f);
        
        _cgf.enabled = false;
    }
}
