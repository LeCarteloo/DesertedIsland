using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    public Text textSticks;
    public Text textWood;
    public Text textStones;
    public Text textIron;
    public Text textCoal;
    public int sticks;
    public int wood;
    public int stones;
    public int iron;
    public int coal;


    // Start is called before the first frame update
    void Start()
    {
        sticks = 0;
        wood = 0;
        stones = 0;
        iron = 0;
        coal = 0;

        textSticks.text = sticks.ToString();
        textWood.text = wood.ToString();
        textStones.text = stones.ToString();
        textIron.text = wood.ToString();
        textCoal.text = stones.ToString();
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
        else if(type == "stone")
        {
            addStone(howMany);
        }
        else if (type == "iron")
        {
            addIron(howMany);
        }
        else if (type == "coal")
        {
            addCoal(howMany);
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
        textWood.text = wood.ToString();
    }

    public void addStone(int stone)
    {
        stones += stone;
        textStones.text = stones.ToString();
    }

    public void addIron(int siron)
    {
        iron += siron;
        textIron.text = iron.ToString();
    }

    public void addCoal(int scaol)
    {
        coal += scaol;
        textCoal.text = coal.ToString();
    }




    public void deleteSticks(int stick)
    {
        sticks -= stick;
        textSticks.text = sticks.ToString();
    }

    public void deleteWood(int nwood)
    {
        wood -= nwood;
        textWood.text = wood.ToString();
    }

    public void deleteStone(int stone)
    {
        stones -= stone;
        textStones.text = stones.ToString();
    }

    public void deleteIron(int siron)
    {
        iron -= siron;
        textIron.text = iron.ToString();
    }

    public void deleteCoal(int scaol)
    {
        coal -= scaol;
        textCoal.text = coal.ToString();
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

    public int getIron()
    {
        return iron;
    }

    public int getCoal()
    {
        return coal;
    }

}
