using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float hp = 100.0f;
    public float food = 100.0f;
    public float water = 100.0f;
    public float temperature = 36.6f;
    public GameObject respawnPanel;
    public bool status = false;

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

        if(hp <= 0) {
            respawnPanel.gameObject.SetActive(true);
        }

    }

    private void FoodSystem()
    {
        if(food > 0 ) {
            food--;
        }
        else {
            hp -= 3;
        }
    }

    private void WaterSystem()
    {
        if(water > 0 ) {
            water--;
        }
        else {
            hp -= 5;
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

    public void addFood(int howMany)
    {
        food += howMany;
        if (food > 140)
        {
            food = 140;
        }
    }

    public void addHp(int howMany)
    {
        hp += howMany;
        if (hp > 100)
        {
            hp = 100;
        }
    }



}
