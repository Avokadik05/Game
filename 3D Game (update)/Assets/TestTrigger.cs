using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    [SerializeField]
    private QTEManager qte;

    [SerializeField]
    private QTEEvent events;

    private void OnTriggerEnter(Collider other)
    {
        qte.startEvent(events);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
