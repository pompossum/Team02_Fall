using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public void RepairStomach(string item)
    {
        GameObject.Find("GameStatus").GetComponent<GameStatus>().food = true;
    }
}
