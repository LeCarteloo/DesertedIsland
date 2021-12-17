using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public int treeHealth = 2;
    public float speed = 20.0f;
    public Transform drop;
    public int minDrop = 1;
    public int maxDrop = 5;
    public float delayDrop = 4.0f;

    private GameObject player;
    private GameObject tree;
    // Start is called before the first frame update
    void Start()
    {
        tree = this.gameObject;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(treeHealth <= 0)
        {
            
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward * speed);
            DoDelayAction(delayDrop);
        }
    }

    void DestroyTree()
    {
        Destroy(gameObject);

        var howManyDrop = Random.Range(minDrop, maxDrop);

        var position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));

        for(int i=0; i<howManyDrop; i++)
        {
            Instantiate(drop, tree.transform.position + new Vector3(Random.Range(0f, 3.0f), Random.Range(0f, 3.0f), Random.Range(0f, 3.0f)) + position, transform.rotation);
        }
    }

    void DoDelayAction(float delayTime)
    {
        StartCoroutine(DelayAction(delayTime));
    }

    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        //Do the action after the delay time has finished.
        DestroyTree();
    }
}
