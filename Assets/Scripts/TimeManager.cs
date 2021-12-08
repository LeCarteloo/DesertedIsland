using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Current Time")]
     [SerializeField]
    private int day = 0;
     [SerializeField]
    private int hour = 0;
     [SerializeField]
    private int minute = 0;

    [Header("Time Settings")]
    // Speed
    public float speed = 0.5f;
    // Time of the day (counter by formula below)
    public float time;
    private float timer;
    private int state = 100;

    public float getTime() {
        return time;
    }
    public int getDay() {
        return day;
    }
    public int getHour() {
        return hour;
    }

    public int getState() {
        return state;
    }

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        hour = 10;
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
                state = Random.Range(0, 100);
            }
            timer = speed;
        }
    }

}
