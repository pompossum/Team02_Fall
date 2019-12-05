using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    public void SignalHelp()
    {
        if (gameObject.name == "ManifestTable")
        {
            GameObject.Find("GameStatus").GetComponent<GameStatus>().table = true;
        }

        else
        {
            GameObject.Find("GameStatus").GetComponent<GameStatus>().signaled = true;
        }
    }
}
