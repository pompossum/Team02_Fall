using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static void Spawn(float x, float y, float z)
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(x, y, z); //Spawns the player with the given values
    }
}
