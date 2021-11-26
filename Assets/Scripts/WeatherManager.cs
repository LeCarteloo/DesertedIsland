using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [Header("Weather Settings")]
    public ParticleSystem particle;
    [Header("Fog Settings")]
    public bool isFogOn = true;
    public Gradient FogColor;
    [Range(0.01f, 0.07f)] public float fogDensity = 0.01f;
    // public Color fogColor;
    [Header("Time")]

    public TimeManager timeManager;

    void Start()
    {
        RenderSettings.fog = isFogOn;
        // fogColor = new Color(191, 213, 192);
        // RenderSettings.fogColor = fogColor;
    }

    void Update()
    {
        // Night fog (not yet)
        if(isFogOn) {
            RenderSettings.fogColor = FogColor.Evaluate(timeManager.getTime());
            RenderSettings.fogDensity = fogDensity;
        }

    }
}
