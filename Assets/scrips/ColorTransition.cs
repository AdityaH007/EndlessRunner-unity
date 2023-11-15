using UnityEngine;

public class ColorTransition : MonoBehaviour
{
    public float transitionDuration = 100f; // Duration of the color transition in seconds

    private Light directionalLight;
    private float hue; // Current hue value

    void Start()
    {
        directionalLight = GetComponent<Light>();

        if (directionalLight == null)
        {
            Debug.LogError("No Light component found on the GameObject.");
            enabled = false; // Disable the script if there is no Light component
        }

        // Initialize the hue based on the current color
        Color.RGBToHSV(directionalLight.color, out hue, out _, out _);
    }

    void Update()
    {
        // Increment the hue value over time
        hue += Time.deltaTime / transitionDuration;

        // Ensure that hue remains in the [0, 1] range
        hue = Mathf.Repeat(hue, 0.5f);

        // Set the light color based on the updated hue value
        directionalLight.color = Color.HSVToRGB(hue, 0.3f, 0.3f);
    }
}
