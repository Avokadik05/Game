using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private Light _flashlight;
    public bool isFlash = false;

    public void OnFlash()
    {
        isFlash = true;
        _flashlight.enabled = true;
    }

    public void OffFlash()
    {
        isFlash = false;
        _flashlight.enabled = false;
    }
}
