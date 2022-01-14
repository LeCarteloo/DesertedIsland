using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsSwitch : MonoBehaviour
{
    public GameObject[] objectID;

    public Color defaultSlotColor;
    public Color selectSlotColor;
    public GameObject[] slots; //kolor aktualnie wybranego slota i odow³anie siê do jego ikony
    public bool[] slotsStatus; //if == true - zajêty slot 
    public int[] slotObjectId;
    public string[] typeObject;
    public int slotSet = 1;

    public Animator animator;
    public bool switchState;

    private void Start()
    {
        switchState = true;
        for(int i=0; i<=9; i++)
        {
            slots[i].transform.GetChild(0).gameObject.SetActive(false);
            slotObjectId[i] = 0;
            typeObject[i] = "none";
}

        SwapWeapons(1);
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
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SwapWeapons(9);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SwapWeapons(10);
        }
    }

    public int getSlotSet()
    {
        return slotSet;
    }

    public bool getItemInSetSlot()
    {
        return slotsStatus[slotSet];
    }

    public void setItemSlot(int ID)
    {
        slotObjectId[slotSet] = ID;
        SwapWeapons(slotSet+1);
    }   

    public void setIconSlot(Sprite icon)
    {
        GameObject iconSlot = slots[slotSet].transform.GetChild(0).gameObject;
        iconSlot.GetComponent<Image>().sprite = icon;
        iconSlot.SetActive(true);
        slotsStatus[slotSet] = true;
    }

    public void setTypeObject(string type)
    {
        typeObject[slotSet] = type;

    }

    public string getTypeWeapon()
    {

        return typeObject[slotSet];
    }

    public void setEmptyIconSlot()
    {

        GameObject iconSlot = slots[slotSet].transform.GetChild(0).gameObject;
        iconSlot.SetActive(false);
        slotsStatus[slotSet] = false;
    }

    public void setStatusSlot(bool status)
    {

        slotsStatus[slotSet] = status;
        SwapWeapons(slotSet+1);
    }

    public int getSetItemId()
    {

        return slotObjectId[slotSet];
    }

    void SwapWeapons(int slot)
    {
        slotSet = slot-1;

        if (switchState)
        {
            animator.SetBool("Switch", true);
            switchState = false;

            for (int i = 0; i < 10; i++)
            {
                slots[i].GetComponent<Image>().color = defaultSlotColor;
            }

            slots[slot - 1].GetComponent<Image>().color = new Color32(123, 122, 25, 225);

            DoDelayAction(0.6f, slot);
        }
    }

    void NotShowSwitch(int slot)
    {

        for(int i=0; i< objectID.Length; i++)
        {
            objectID[i].SetActive(false);
        }
 

        if (slot == 1)
        {
            if(slotsStatus[slotSet] == true) {
                animator.SetBool("WeaponIsOn", true);
                objectID[slotObjectId[slotSet]].SetActive(true);
            }
            else
            {
                animator.SetBool("WeaponIsOn", false);
            }
        }
        else if (slot == 2)
        {
            if (slotsStatus[slotSet] == true)
            {
                animator.SetBool("WeaponIsOn", true);
                objectID[slotObjectId[slotSet]].SetActive(true);
            }
            else
            {
                animator.SetBool("WeaponIsOn", false);
            }
        }
        else if (slot == 3)
        {
            if (slotsStatus[slotSet] == true)
            {
                animator.SetBool("WeaponIsOn", true);
                objectID[slotObjectId[slotSet]].SetActive(true);
            }
            else
            {
                animator.SetBool("WeaponIsOn", false);
            }
        }
        else if (slot == 4)
        {
            if (slotsStatus[slotSet] == true)
            {
                animator.SetBool("WeaponIsOn", true);
                objectID[slotObjectId[slotSet]].SetActive(true);
            }
            else
            {
                animator.SetBool("WeaponIsOn", false);
            }
        }
        else if (slot == 5)
        {
            if (slotsStatus[slotSet] == true)
            {
                animator.SetBool("WeaponIsOn", true);
                objectID[slotObjectId[slotSet]].SetActive(true);
            }
            else
            {
                animator.SetBool("WeaponIsOn", false);
            }
        }
        else if (slot == 6)
        {
            if (slotsStatus[slotSet] == true)
            {
                animator.SetBool("WeaponIsOn", true);
                objectID[slotObjectId[slotSet]].SetActive(true);
            }
            else
            {
                animator.SetBool("WeaponIsOn", false);
            }
        }
        else if (slot == 7)
        {
            if (slotsStatus[slotSet] == true)
            {
                animator.SetBool("WeaponIsOn", true);
                objectID[slotObjectId[slotSet]].SetActive(true);
            }
            else
            {
                animator.SetBool("WeaponIsOn", false);
            }
        }
        else if (slot == 8)
        {
            if (slotsStatus[slotSet] == true)
            {
                animator.SetBool("WeaponIsOn", true);
                objectID[slotObjectId[slotSet]].SetActive(true);
            }
            else
            {
                animator.SetBool("WeaponIsOn", false);
            }
        }
    }

    void DoDelayAction(float delayTime, int slot)
    {
        StartCoroutine(DelayAction(delayTime));
        StartCoroutine(SwitchItem(delayTime/2 + 0.3f, slot));
    }

    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        //Do the action after the delay time has finished.
        animator.SetBool("Switch", false);
        switchState = true;
        
    }

    IEnumerator SwitchItem(float delayTime, int slot)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        //Do the action after the delay time has finished.

        NotShowSwitch(slot);
    }
}
