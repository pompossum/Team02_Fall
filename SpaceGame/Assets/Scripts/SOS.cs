using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOS : MonoBehaviour
{
    public void RepairSOS()
    {
        if (gameObject.name == "Security Override Keypad")
        {
            GameObject.Find("GameStatus").GetComponent<GameStatus>().secOverwritten = true;
        }

        else
        {
            GameObject.Find("GameStatus").GetComponent<GameStatus>().sosPlacement = true;
        }
    }
}
