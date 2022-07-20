using UnityEngine;
using UnityEngine.Events;

public class ForestCutTrigger : MonoBehaviour
{
    public UnityEvent _enter;

    private void OnTriggerEnter(Collider other)
    {
        _enter.Invoke();
    }
}
