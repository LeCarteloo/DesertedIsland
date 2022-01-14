using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    public Text textSticks;
    public Text textWood;
    public Text textstones;
    public int sticks;
    public int wood;
    public int stones;


    // Start is called before the first frame update
    void Start()
    {
        sticks = 0;
        wood = 0;
        stones = 0;
    }

    public void addSomething(string type, int howMany)
    {
        if(type == "sticks")
        {
            addSticks(howMany);
        }
        else if(type == "wood")
        {
            addWood(howMany);
        }
        else if(type == "stones")
        {
            addStone(howMany);
        }
        else
        {

        }
    }

    public void addSticks(int stick)
    {
        sticks += stick;
        textSticks.text = sticks.ToString();
    }

    public void addWood(int nwood)
    {
        wood += nwood;
        textWood.text = sticks.ToString();
    }

    public void addStone(int stone)
    {
        stones += stone;
        textstones.text = sticks.ToString();
    }

    public void deleteSticks(int stick)
    {
        sticks -= stick;
        textSticks.text = sticks.ToString();
    }

    public void deleteWood(int nwood)
    {
        wood -= nwood;
        textWood.text = sticks.ToString();
    }

    public void deleteStone(int stone)
    {
        stones -= stone;
        textstones.text = sticks.ToString();
    }

    public int getSticks()
    {
        return sticks;
    }

    public int getWood()
    {
        return wood;
    }

    public int getStone()
    {
        return stones;
    }

}
