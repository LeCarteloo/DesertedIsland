using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float hp = 100.0f;
    public float food = 100.0f;
    public float water = 100.0f;
    public float temperature = 36.6f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FoodSystem", 0, 5);
        InvokeRepeating("WaterSystem", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        StatusTemperature();
    }

    private void FoodSystem()
    {
        food--;
        if (food < 0)
        {
            //if 0 food
        }
    }

    private void WaterSystem()
    {
        water--;
        if (water < 0)
        {
            //if 0 water
        }
    }

    private void StatusTemperature()
    {
        if (temperature >= 40)
        {
            //if hot
            TemperatureHigh();
        }

        if (temperature <= 0)
        {
            //if cold
            TemperatureLow();
        }

        if (temperature > 0 && temperature < 40)
        {
            //if normal
            TemperatureNormal();
        }
    }

    private void TemperatureHigh()
    {

    }

    private void TemperatureLow()
    {

    }

    private void TemperatureNormal()
    {

    }

}
