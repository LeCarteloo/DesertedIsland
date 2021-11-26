using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    [Header("Light Settings")]
    // Light source
    public Light DirectionalLight;
    // Colors
    public Gradient AmbientColor;
    public Gradient LightHue;
    [Header("Time")]
    public TimeManager timeManager;

    private void Update()
    {
        updateHour(timeManager.getTime()); 
    }

    private void updateHour(float time)
    {
        // Ambient color and light color
        RenderSettings.ambientLight = AmbientColor.Evaluate(time);
        DirectionalLight.color = LightHue.Evaluate(time);

        // Rotate light (night and day)
        DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((time * 360f) - 90f, 170f, 0));

    }
}
