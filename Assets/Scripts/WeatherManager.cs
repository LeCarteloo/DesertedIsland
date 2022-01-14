using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [Header("Weather Settings")]
    public GameObject rain;
    public GameObject heavyRain;
    public GameObject snow;
    [Header("Fog Settings")]
    public bool isFogOn = true;
    public Gradient FogColor;
    [Range(0.0005f, 0.07f)] public float fogDensity = 0.0009f;
    // public Color fogColor;
    [Header("Time")]

    public TimeManager timeManager;
    private int temp;
    private bool isActive = false;

    void Start()
    {
        RenderSettings.fog = isFogOn;
        RenderSettings.fogDensity = fogDensity;
        
        rain.SetActive(false);
        heavyRain.SetActive(false);
        snow.SetActive(false);
    }

    void Update()
    {
        RenderSettings.fogColor = FogColor.Evaluate(timeManager.getTime());

        turnWeather(rain, 0, 10);
        turnWeather(heavyRain, 10, 15);
        turnWeather(snow, 15, 20);

        turnFog(20, 30);
    }

    private void turnWeather(GameObject gameObject, int from, int to) {
        if(timeManager.getState() < to && timeManager.getState() > from && !isActive) {
            isActive = true;
            gameObject.SetActive(true);
            temp = timeManager.getHour() + Random.Range(5,12) >= 23 ? 12 : timeManager.getHour() + Random.Range(5,12);
            Debug.Log(temp);
        }
        if(temp == timeManager.getHour()) {
            isActive = false;
            gameObject.SetActive(false);
        }
    }

    private void turnFog(int from, int to) {
        if(timeManager.getState() < to && timeManager.getState() > from && !isActive) {
            isActive = true;
            RenderSettings.fogDensity = Random.Range(0.01f, 0.05f);
            temp = timeManager.getHour() + Random.Range(5,12) >= 23 ? 12 : timeManager.getHour() + Random.Range(5,12);
            Debug.Log(temp);
        }
        if(temp == timeManager.getHour()) {
            isActive = false;
            RenderSettings.fogDensity = 0.01f;
        }
    }
}
