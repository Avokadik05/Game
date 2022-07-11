using UnityEngine;

public class ForestCutTrigger : MonoBehaviour
{
    [SerializeField]
    private CutScene cut;

    private void OnTriggerEnter(Collider other)
    {
        cut.CutScenePlay();
    }
}
