using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Dead();
        }
    }

    void ApplyDammage(int dmg)
    {
        health -= dmg;
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
