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
    [Header("Fog not yet implemented")]
    public Gradient FogColor;

    [Header("Speed Settings")]
    // Faster cycle
    public bool fastCycle;
    // Speed of day and night cycle
    public float speed;
    // Time of the day (in hours)
    [Range(0, 24)] public float timeOfDay;

    private void Start() {
        if(fastCycle) {
            // Few seconds
            speed = 1f;
        } else {
            // 30 minutes
            speed = 0.004f;
        }
    }

    private void Update()
    {
        timeOfDay = timeOfDay + Time.deltaTime * speed;
        timeOfDay = timeOfDay % 24;
        updateHour(timeOfDay / 24f);
    }


    private void updateHour(float time)
    {
        // If fog is turned on in enviroment setting
        if(RenderSettings.fog) {
            RenderSettings.fogColor = FogColor.Evaluate(time);
        }

        // Ambient color and light color
        RenderSettings.ambientLight = AmbientColor.Evaluate(time);
        DirectionalLight.color = LightHue.Evaluate(time);

        // Rotate light (night and day)
        DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((time * 360f) - 90f, 170f, 0));

    }
}
