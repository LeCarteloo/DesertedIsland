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

    private void Start() {
        healthBar = GetComponent<Image>();
        // var player = GameObject.Find("Player").GetComponent<FirstPerson>();
        // Debug.Log(player);
        maxHealth = 100f;
    }
    private void Update() {
        // currentHealth = player.hp;
        // healthBar.fillAmount = 50;
    }
}
