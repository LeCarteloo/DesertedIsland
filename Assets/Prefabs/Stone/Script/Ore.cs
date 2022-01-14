using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public int Health = 2;
    public Transform drop;
    public int minDrop = 1;
    public int maxDrop = 5;

    private GameObject player;
    private GameObject ore;

    // Start is called before the first frame update
    void Start()
    {
        ore = this.gameObject;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            DestroyOre();
        }
    }

    void DestroyOre()
    {
        Destroy(gameObject);

        var howManyDrop = Random.Range(minDrop, maxDrop);

        var position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));

        for (int i = 0; i < howManyDrop; i++)
        {
            Instantiate(drop, ore.transform.position + new Vector3(Random.Range(0f, 3.0f), Random.Range(0f, 3.0f), Random.Range(0f, 3.0f)) + position, transform.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "HandItem")
        {
            Health -= 1;
        }
    }
}
