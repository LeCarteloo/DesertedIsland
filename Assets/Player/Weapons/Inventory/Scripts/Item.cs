using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ObjectID;
    public WeaponsSwitch weaponSwitch;
    public Text pickIt;
    private bool canPick;
    public Sprite icon;


    //aktualny slot czy wolny?
    //

    private void Start()
    {
        canPick = false;

        weaponSwitch = FindObjectOfType<WeaponsSwitch>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canPick)
        {
            bool statusSlot = weaponSwitch.getItemInSetSlot();

            if (statusSlot)
            {
                pickIt.text = "Ten slot jest zajêty";
                DoDelayAction(1.5f);
            }
            else
            {
                weaponSwitch.setIconSlot(icon);
                weaponSwitch.setItemSlot(ObjectID);
                pickIt.gameObject.SetActive(false);
                DestroyItem();
            }
        }
    }

    void PickToInventory()
    {

    }

    void DestroyItem()
    {
        Debug.Log("DESTORY");
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pickIt.text = "Naciœnij [F] aby podnieœæ";
            pickIt.gameObject.SetActive(true);
            canPick = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pickIt.gameObject.SetActive(false);
            canPick = false;
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
        pickIt.gameObject.SetActive(false);

    }
}
