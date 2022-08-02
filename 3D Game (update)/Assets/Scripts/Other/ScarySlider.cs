using UnityEngine;
using UnityEngine.UI;

public class ScarySlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Update()
    {
        Decline();
    }

    public void Increase()
    {
        _slider.value += 200f * Time.deltaTime * 5;
        print(_slider.value);
    }

    public void Decline()
    {
        if (Input.GetKey(KeyCode.H))
        {
            _slider.value -= 2f * Time.deltaTime * 2;
        }
    }
}
