using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour
{
    public WeaponsSwitch weaponSwitch;
    public GameObject[] items;
    public GameObject player;
    private Transform dropPosition;

    // Start is called before the first frame update
    void Start()
    {
        weaponSwitch = FindObjectOfType<WeaponsSwitch>();
        player = GameObject.FindGameObjectWithTag("Player");
        dropPosition = player.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bool statusSlot = weaponSwitch.getItemInSetSlot();

            if (statusSlot)
            {
                weaponSwitch.setStatusSlot(false);
                weaponSwitch.setEmptyIconSlot();
                Instantiate(items[weaponSwitch.getSetItemId()], dropPosition.transform.position, Quaternion.identity);
            }
        }
    }


}
