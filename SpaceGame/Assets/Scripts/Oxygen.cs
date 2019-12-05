using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    public void RepairHull()
    {
        if (gameObject.name == "Hull Breach")
        {
            GameObject.Find("GameStatus").GetComponent<GameStatus>().hullFix = true;
            Destroy(gameObject);
			Debug.Log("RepairHull()");
        }

        else
        {
            GameObject.Find("GameStatus").GetComponent<GameStatus>().lifeSupportFix = true;
        }
    }
}
