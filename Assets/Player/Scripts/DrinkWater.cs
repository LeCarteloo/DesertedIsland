using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkWater : MonoBehaviour
{
    private Life player;
    private float rayLength = 1000;
    public LayerMask layerMask;


    // Update is called once per frame
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>();
    }


    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if(Physics.Raycast(transform.position, forward, out hit, rayLength, layerMask.value)) {
            if(hit.collider.CompareTag("WaterGround")) {
                Event e = Event.current;
                if(Input.GetKeyDown(KeyCode.Mouse1)) {
                    drinkWater();
                }
            }
        }
    }

    private void drinkWater() {
        if(player.water <= 80) {
            player.water += 20;
        } else {
            player.water = 100;
        }
    }
}
