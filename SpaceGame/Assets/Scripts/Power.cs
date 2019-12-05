using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public void RepairPower()
    {
        if (gameObject.name == "Fuel Cell Slot 1")
        {
            GameObject.Find("GameStatus").GetComponent<GameStatus>().cell1 = true;
        }

        else if (gameObject.name == "Fuel Cell Slot 2")
        {
            GameObject.Find("GameStatus").GetComponent<GameStatus>().cell2 = true;
        }

        else if (gameObject.name == "Fuel Cell Slot 3")
        {
            GameObject.Find("GameStatus").GetComponent<GameStatus>().cell3 = true;
        }

        else
        {
            GameObject.Find("GameStatus").GetComponent<GameStatus>().leakFixed = true;
        }
    }
}
