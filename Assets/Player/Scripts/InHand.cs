using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHand : MonoBehaviour
{
    public int damage = 50;
    public float distance;
    public float maxDistance = 2;

    public bool canAtack = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            DoDelayAction(0.9f);

            canAtack = false;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;
                if (distance < maxDistance)
                {
                    hit.transform.SendMessage("ApplyDammage", damage, SendMessageOptions.DontRequireReceiver);

                }
            }
            Debug.Log("TAK");
            
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
        canAtack = true;
    }
}
