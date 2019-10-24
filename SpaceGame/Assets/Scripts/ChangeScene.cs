using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
