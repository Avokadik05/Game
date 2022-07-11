using UnityEngine;

[ExecuteInEditMode]
public class RGBSky : MonoBehaviour
{
    [SerializeField] Gradient dirLightGradient;
    [SerializeField] Gradient ambientLightGradient;

    [SerializeField, Range(1, 3600)] float timeDayInSeconds = 60;
    [SerializeField, Range(0f, 1f)] float timeProgress;

    [SerializeField] Light dirLight;

    private void FixedUpdate()
    {
        if (Application.isPlaying)
            timeProgress += Time.fixedDeltaTime / timeDayInSeconds;

        if (timeProgress > 1f)
            timeProgress = 0f;

        dirLight.color = dirLightGradient.Evaluate(timeProgress);
        RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);
    }
}
