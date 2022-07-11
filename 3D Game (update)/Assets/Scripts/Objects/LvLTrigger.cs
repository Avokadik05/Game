using UnityEngine;
using UnityEngine.SceneManagement;

public class LvLTrigger : MonoBehaviour
{
    [SerializeField]
    private string sceneID;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneID);
    }
}
