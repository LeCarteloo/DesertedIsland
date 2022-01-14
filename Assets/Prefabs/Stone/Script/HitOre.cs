using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOre : MonoBehaviour
{
    public float rayLength = 10;

    private Ore ore;
    private WeaponsSwitch weaponSwitch;
    private string typeWeapon;
    private bool canHit;

    private float distance;

    void Start()
    {
        weaponSwitch = FindObjectOfType<WeaponsSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            DoDelayAction(0.9f);
            canHit = false;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;

                if (distance <= rayLength)
                {
                    ore = GameObject.Find(hit.collider.gameObject.name).GetComponent<Ore>();
                    typeWeapon = weaponSwitch.getTypeWeapon();

                    if (typeWeapon == "pickaxe")
                    {
                        //ore.Health -= 1;
                    }
                }

            }
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
        canHit = true;
    }
}
