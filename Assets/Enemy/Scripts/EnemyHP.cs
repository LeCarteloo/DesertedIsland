using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int health = 100;
    private bool canHit;
    private GameObject animal;
    public Transform drop;

    // Start is called before the first frame update
    void Start()
    {
        animal = this.gameObject;
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
        Instantiate(drop, animal.transform.position + new Vector3(0f, 0f, 0f), transform.rotation);
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
