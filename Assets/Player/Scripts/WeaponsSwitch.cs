using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsSwitch : MonoBehaviour
{
    public GameObject sword;
    public GameObject axe;

    public Color defaultSlotColor;
    public Color selectSlotColor;
    public GameObject[] slots;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapons(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapWeapons(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwapWeapons(3);
        }
    }

    void SwapWeapons(int key)
    {
        for(int i=0; i<3; i++)
        {
            slots[i].GetComponent<Image>().color = defaultSlotColor;
        }

        Debug.Log(key);
        Debug.Log(slots[key - 1].GetComponent<Image>().name);
        slots[key-1].GetComponent<Image>().color = new Color32(123, 122, 25, 225);
        //GameObject item = slots[key-1].transform.GetChild(0).gameObject;
        //item.GetComponent<Image>().color = selectSlotColor;

        if (key == 1)
        {
            animator.SetBool("WeaponIsOn", true);
            sword.SetActive(true);
            axe.SetActive(false);
        }
        else if(key == 2)
        {
            animator.SetBool("WeaponIsOn", true);
            sword.SetActive(false);
            axe.SetActive(true);
        }
        else if(key == 3)
        {
            animator.SetBool("WeaponIsOn", false);
            sword.SetActive(false);
            axe.SetActive(false);
        }
    }
}
