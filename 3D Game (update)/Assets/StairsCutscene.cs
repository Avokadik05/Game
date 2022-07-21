using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StairsCutscene : MonoBehaviour
{
    public UnityEvent _stairs;
    
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Stairs());
    }

    IEnumerator Stairs()
    {
        _stairs.Invoke();

        yield return new WaitForSeconds(4);

        Destroy(gameObject);
    }
}
