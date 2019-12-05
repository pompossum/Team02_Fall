using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEDSpawn : MonoBehaviour
{
    public void CreateIED()
    {
        if (GameStatus.GetLength() < 12)
        {
            GameStatus.AddInventory(GameObject.Find("IED").gameObject);
        }
    }
}

