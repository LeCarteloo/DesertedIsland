using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireHit : MonoBehaviour
{
    public int DMG;
    private Life player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            DoDelayAction(1);
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
        player.hp -= 0.05f;
    }
}
