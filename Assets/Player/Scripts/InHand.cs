using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHand : MonoBehaviour
{
    public int damage = 50;
    public float distance;
    public float maxDistance = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;
                if (distance < maxDistance)
                {
                    hit.transform.SendMessage("ApplyDammage", damage, SendMessageOptions.DontRequireReceiver);
                }
            }
        }

    }
}
