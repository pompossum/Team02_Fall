using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Jeff Wakeman
// 10/15/19 Created
// Used in every scene which isn't a menu
// Attached to every door in a scene that isn't a menu
// Changes scenes dependant on what door you walk through
public class ChangeScene : MonoBehaviour
{
    //When the player enters the door's collider 
    public void OnTriggerEnter(Collider other)
    {
        string levelname = this.name;
        if (other.gameObject.CompareTag("Player"))
        {
            string pLevel = SceneManager.GetActiveScene().name;//When the collider is entered, but before the next scene loads, gets the current scene name and stores in as the previous level
            //Debug.Log("pLevel: " + pLevel);
            GameStatus.GetCurrent().prevLevel = pLevel;
            SceneManager.LoadScene(levelname);
        }
    }
}
