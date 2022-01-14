using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int health = 100;
    private bool canHit;

    // Start is called before the first frame update
    void Start()
    {
        canHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Dead();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            canHit = true;
        }
        else
        {
            canHit = false;
        }
    }

    void ApplyDammage(int dmg)
    {
        //health -= dmg;
    }

    void Dead()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Weapon")
        {
            Debug.Log("HIT SARNA");
            health -= 100;

            if (canHit)
            {
                Debug.Log(canHit);
            }
        }
    }
}
