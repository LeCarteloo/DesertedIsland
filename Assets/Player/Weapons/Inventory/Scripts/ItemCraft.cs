using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCraft : MonoBehaviour
{
    public Weapons weapons;
    public Text pickIt;
    private bool canPick;
    public string type;
    private GameObject objectText;


    private void Start()
    {
        canPick = false;

        weapons = FindObjectOfType<Weapons>();
        objectText = GameObject.FindGameObjectWithTag("uselessTagForPickIt");
        pickIt = objectText.GetComponent<Text>();
        pickIt.text = "";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canPick)
        {
            weapons.addSomething(type, 1);
            DestroyItem();
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
            canPick = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pickIt.text = "";
            canPick = false;
        }
    }

}
