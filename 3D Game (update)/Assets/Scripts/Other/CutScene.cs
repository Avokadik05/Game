using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class CutScene : MonoBehaviour
{
    [SerializeField]
    private CustomCharacterController controller;
    [SerializeField]
    private CinemachineVirtualCamera cam;
    [SerializeField]
    private PlayableDirector director;
    [SerializeField]
    private QTEEvent qte;
    [SerializeField]
    private GameObject _ui;

    public void OffController()
    {
        controller.enabled = false;
        cam.enabled = false;
        _ui.SetActive(false);
    }

    public void OnController()
    {
        controller.enabled = true;
        cam.enabled = true;
        _ui.SetActive(true);
    }

    public void CutScenePlay()
    {
        director.Play();
    }
}
