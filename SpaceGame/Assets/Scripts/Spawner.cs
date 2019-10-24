using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jeff Wakeman
//10/17/19
//Used in all the scenes with the GameStatus prefab
//Attached to GameStatus prefab
//Spawns the player within the room at a certain location
public class Spawner : MonoBehaviour
{
    public static void Spawn(float x, float y, float z)
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(x, y, z); //Spawns the player with the given values
    }
}
