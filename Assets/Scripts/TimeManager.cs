using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Current Time")]
    public int day = 0;
    public int hour = 0;
    public int minute = 0;

    [Header("Time Settings")]
    // Speed
    public float speed = 0.5f;
    // Time of the day (counter by formula below)
    public float time;

    private float timer;

    public float getTime() {
        return time;
    }

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        hour = 0;
        timer = speed;
    }

    // Update is called once per frame
    void Update()
    {
        time = ( ( hour + ( (float) minute / 60 ) ) % 24) / 24;
        timer = timer - Time.deltaTime;

        if(timer <= 0) {
            minute++;
            if(minute >= 60) {
                hour++;
                minute = 0;
                if(hour >= 24) {
                    hour = 0;
                    day++;
                }
            }
            timer = speed;
        }
    }

}
