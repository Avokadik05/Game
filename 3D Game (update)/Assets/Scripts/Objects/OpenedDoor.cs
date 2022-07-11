using UnityEngine;

public class OpenedDoor : MonoBehaviour
{
    private bool isOpened;
    [SerializeField] private Animator anim;

    public void Open()
    {
        anim.SetBool("isOpened", isOpened);
        isOpened = !isOpened;
    }

    public void Closed()
    {
        anim.SetTrigger("isClosed");
    }
}
