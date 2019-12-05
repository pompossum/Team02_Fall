using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerusSerumSpawn : MonoBehaviour
{
    public void CreateLazerus()
    {
        if (GameStatus.GetLength() < 12)
        {
            GameStatus.AddInventory(GameObject.Find("LazerusSerum").gameObject);
        }
    }
}