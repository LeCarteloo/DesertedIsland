using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class StatusBars : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth = 100f;
    private Life player;

    private void Start() {
        healthBar = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>();
        
        Debug.Log(player.hp);
        Debug.Log(player.water);
        Debug.Log(player.temperature);
        Debug.Log(player.food);
        maxHealth = 100f;
    }
    private void Update() {
        currentHealth = player.hp;
        healthBar.fillAmount = 50;
    }
}
