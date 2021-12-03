using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsSwitch : MonoBehaviour
{
    public GameObject sword;
    public GameObject axe;
    public GameObject meat;
    public GameObject axe2;
    public GameObject knife;
    public GameObject torch;
    public GameObject axe3;

    public Color defaultSlotColor;
    public Color selectSlotColor;
    public GameObject[] slots;

    public Animator animator;
    public bool switchState;

    private void Start()
    {
        switchState = true;
    }

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
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwapWeapons(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SwapWeapons(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SwapWeapons(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SwapWeapons(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SwapWeapons(8);
        }
    }

    void SwapWeapons(int key)
    {
        if (switchState)
        {
            animator.SetBool("Switch", true);
            switchState = false;

            for (int i = 0; i < 8; i++)
            {
                slots[i].GetComponent<Image>().color = defaultSlotColor;
            }

            slots[key - 1].GetComponent<Image>().color = new Color32(123, 122, 25, 225);

            DoDelayAction(0.6f, key);
        }
    }

    void NotShowSwitch(int key)
    {

        axe.SetActive(false);
        sword.SetActive(false);
        axe2.SetActive(false);
        meat.SetActive(false);
        axe3.SetActive(false);
        knife.SetActive(false);
        torch.SetActive(false);



        if (key == 1)
        {
            animator.SetBool("WeaponIsOn", true);
            sword.SetActive(true);
        }
        else if (key == 2)
        {
            animator.SetBool("WeaponIsOn", true);
            axe.SetActive(true);
        }
        else if (key == 3)
        {
            animator.SetBool("WeaponIsOn", false);
        }
        else if (key == 4)
        {
            animator.SetBool("WeaponIsOn", true);
            axe2.SetActive(true);
        }
        else if (key == 5)
        {
            animator.SetBool("WeaponIsOn", true);
            meat.SetActive(true);
        }
        else if (key == 6)
        {
            animator.SetBool("WeaponIsOn", true);
            knife.SetActive(true);
        }
        else if (key == 7)
        {
            animator.SetBool("WeaponIsOn", true);
            torch.SetActive(true);
        }
        else if (key == 8)
        {
            animator.SetBool("WeaponIsOn", true);
            axe3.SetActive(true);
        }
    }

    void DoDelayAction(float delayTime, int key)
    {
        StartCoroutine(DelayAction(delayTime));
        StartCoroutine(SwitchItem(delayTime/2, key));
    }

    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        //Do the action after the delay time has finished.
        animator.SetBool("Switch", false);
        switchState = true;
        
    }

    IEnumerator SwitchItem(float delayTime, int key)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        //Do the action after the delay time has finished.

        NotShowSwitch(key);
    }
}
