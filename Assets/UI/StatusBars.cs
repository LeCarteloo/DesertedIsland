using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class StatusBars : MonoBehaviour
{
    private Image healthBar;
    private Image foodBar;
    private Image waterBar;

    private Life player;

    private void Start() {
        healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<Image>();
        foodBar = GameObject.FindGameObjectWithTag("Food").GetComponent<Image>();
        waterBar = GameObject.FindGameObjectWithTag("Water").GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>();

        Debug.Log("hp" + player.hp);
        Debug.Log("water" + player.water);
        Debug.Log("temperature" + player.temperature);
        Debug.Log("food" + player.food);

    }
    private void Update() {
        healthBar.fillAmount = player.hp / 100f;
        waterBar.fillAmount = player.water / 100f;
        foodBar.fillAmount = player.food / 100f;
    }
}
