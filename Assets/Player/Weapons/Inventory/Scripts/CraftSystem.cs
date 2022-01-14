using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSystem : MonoBehaviour
{
    public GameObject craftGUI;
    private Transform dropPosition;
    public GameObject player;
    public GameObject[] items;
    private GameObject objectText;

    public Weapons weapons;
    public Text pickIt;


    // Start is called before the first frame update
    void Start()
    {
        weapons = FindObjectOfType<Weapons>();
        player = GameObject.FindGameObjectWithTag("Player");
        dropPosition = player.transform.GetChild(0);

        objectText = GameObject.FindGameObjectWithTag("uselessTagForPickIt");
        pickIt = objectText.GetComponent<Text>();
        pickIt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Cursor.visible = true;
            craftGUI.SetActive(!craftGUI.activeSelf);
        }
    }

    public void CreateWarAxe()
    {
        int sticks = 6;
        int iron = 5;

        if (weapons.getSticks() >= sticks && weapons.getIron() >= iron)
        {
            Instantiate(items[0], dropPosition.transform.position, Quaternion.identity);
            weapons.deleteSticks(sticks);
            weapons.deleteIron(iron);
        }
        else
        {
            pickIt.text = "Brak wymaganych surowców!";
            DoDelayAction(3.0f);
        }
    }

    public void CreateTreeAxe()
    {
        int sticks = 3;
        int stones = 5;

        if (weapons.getSticks() >= sticks && weapons.getStone() >= stones)
        {
            Instantiate(items[1], dropPosition.transform.position, Quaternion.identity);
            weapons.deleteSticks(sticks);
            weapons.deleteStone(stones);
        }
        else
        {
            pickIt.text = "Brak wymaganych surowców!";
            DoDelayAction(3.0f);
        }
    }

    public void CreatePickaxe()
    {
        int sticks = 3;
        int stones = 6;

        if (weapons.getSticks() >= sticks && weapons.getStone() >= stones)
        {
            Instantiate(items[2], dropPosition.transform.position, Quaternion.identity);
            weapons.deleteSticks(sticks);
            weapons.deleteStone(stones);
        }
        else
        {
            pickIt.text = "Brak wymaganych surowców!";
            DoDelayAction(3.0f);
        }

    }

    public void CreateSword()
    {
        int sticks = 2;
        int iron = 5;

        if (weapons.getSticks() >= sticks && weapons.getIron() >= iron)
        {
            Instantiate(items[3], dropPosition.transform.position, Quaternion.identity);
            weapons.deleteSticks(sticks);
            weapons.deleteIron(iron);
        }
        else
        {
            pickIt.text = "Brak wymaganych surowców!";
            DoDelayAction(3.0f);
        }
    }

    public void CreateTorch()
    {
        int sticks = 1;
        int coal = 1;

        if (weapons.getSticks() >= sticks && weapons.getCoal() >= coal)
        {
            Instantiate(items[4], dropPosition.transform.position, Quaternion.identity);
            weapons.deleteSticks(sticks);
            weapons.deleteCoal(coal);
        }
        else
        {
            pickIt.text = "Brak wymaganych surowców!";
            DoDelayAction(3.0f);
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
        pickIt.text = "";

    }
}
